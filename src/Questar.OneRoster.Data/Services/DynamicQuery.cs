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
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Extensions.Internal;

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
                    throw new InvalidOperationException($"Could not find property '{member}' on type '{type.Name}'.");

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
}