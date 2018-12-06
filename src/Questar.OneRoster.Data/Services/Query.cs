namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading.Tasks;
    using Filtering;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Extensions.Internal;
    using OneRoster.Collections;
    using Sorting;

    public class OrderedDynamicQuery<T> : DynamicQuery<T>, IOrderedDynamicQuery
    {
        public OrderedDynamicQuery(IQueryable<T> source, IEnumerable<string> fields) : base(source, fields)
        {
        }

        public IPage ToPage(int offset, int limit)
        {
            var count = Source.Count();
            var items = Invoke(Source.Skip(offset).Take(limit)).AsEnumerable().Select(Map).ToList();

            return new Page<dynamic>(offset / limit, limit, count, items);
        }

        public async Task<IPage> ToPageAsync(int offset, int limit)
        {
            var count = Source.CountAsync();
            var items = Invoke(Source.Skip(offset).Take(limit)).AsAsyncEnumerable().Select(Map).ToList();

            return new Page<dynamic>(offset / limit, limit, await count, await items);
        }
    }

    public class DynamicQuery<T> : IDynamicQuery
    {
        public DynamicQuery(IQueryable<T> source, IEnumerable<string> fields)
        {
            Source = source;
            Members = fields.ToList();
            Mapper = new Lazy<Delegate>(GetMapper);
        }

        protected IQueryable<T> Source { get; }

        protected Lazy<Delegate> Mapper { get; }

        public IEnumerable<string> Members { get; }

        public object Single() => Source.Single();

        public async Task<object> SingleAsync() => await Invoke(Source).SingleAsync();

        IList IQuery.ToList() => ToList();

        async Task<IList> IQuery.ToListAsync() => await ToListAsync();

        private Delegate GetMapper()
        {
            var item = Expression.Parameter(typeof(T));
            var dictionary = Expression.Parameter(typeof(IDictionary<string, object>));
            var assignments =
                from field in Members
                let indexer = Expression.Property(dictionary, "Item", Expression.Constant(field))
                let property = Expression.Property(item, field)
                let right = property.Type.IsValueType
                    ? (Expression) Expression.Convert(property, typeof(object))
                    : property
                select (Expression) Expression.Assign(indexer, right);
            var body = Expression.Block(assignments);
            var func = Expression.Lambda(body, item, dictionary);
            return func.Compile();
        }

        protected IQueryable<T> Invoke(IQueryable<T> queryable)
        {
            var type = typeof(T);
            var parameter = Expression.Parameter(type);
            var bindings = Members.Select(member =>
            {
                var property = type.GetProperty(member, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                    throw new InvalidOperationException($"Could not find property '{member}' on type '{type.Name}'");

                // TODO get full path

                return Expression.Bind(property, Expression.Property(parameter, member));
            });
            var body = Expression.MemberInit(Expression.New(type), bindings);
            var selector = Expression.Lambda(body, parameter);
            var call = Expression.Call(typeof(Queryable), "Select", new[] { type, type }, Source.Expression, Expression.Quote(selector));
            var query = queryable.Provider.CreateQuery<T>(call);
            return query;
        }

        protected dynamic Map(T item)
        {
            var expando = new ExpandoObject();
            var dictionary = (IDictionary<string, object>) expando;
            Mapper.Value.DynamicInvoke(item, dictionary);
            return expando;
        }

        public List<dynamic> ToList() => Invoke(Source).AsEnumerable().Select(Map).ToList();

        public async Task<List<dynamic>> ToListAsync() => await Invoke(Source).AsAsyncEnumerable().Select(Map).ToList();
    }

    public class Query<T> : IQuery<T>
    {
        public Query(IQueryable<T> source, Func<T, object> keySelector, Func<object, object, bool> keyComparer)
        {
            Source = source;
            KeySelector = keySelector;
            KeyComparer = keyComparer;
        }

        protected IQueryable<T> Source { get; }

        protected Func<T, object> KeySelector { get; }

        protected Func<object, object, bool> KeyComparer { get; }

        protected virtual IDynamicQuery ToDynamic(IEnumerable<string> fields)
            => new DynamicQuery<T>(Source, fields);

        public IDynamicQuery Fields(IEnumerable<string> fields)
            => ToDynamic(fields);

        public virtual T Single()
            => Source.Single();

        public virtual Task<T> SingleAsync()
            => Source.SingleAsync();

        IList<T> IQuery<T>.ToList()
            => ToList();

        async Task<IList<T>> IQuery<T>.ToListAsync()
            => await ToListAsync();

        public virtual IQuery<T> Where(FilterExpression<T> predicate)
            => new Query<T>(Source.Where(predicate), KeySelector, KeyComparer);

        public virtual IQuery<T> WhereHasKey(object key)
            => new Query<T>(Source.Where(source => KeyComparer(KeySelector(source), key)), KeySelector, KeyComparer);

        public virtual IOrderedQuery<T> Sort(string field, SortDirection? direction)
            => new OrderedQuery<T>(Source.SortBy(field, direction), KeySelector, KeyComparer);

        object IQuery.Single()
            => Single();

        async Task<object> IQuery.SingleAsync()
            => await SingleAsync();

        IList IQuery.ToList()
            => ToList();

        async Task<IList> IQuery.ToListAsync()
            => await ToListAsync();

        public virtual List<T> ToList()
            => Source.ToList();

        public virtual Task<List<T>> ToListAsync()
            => Source.ToListAsync();
    }
}