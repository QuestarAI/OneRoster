namespace Questar.OneRoster.DataServices.EntityFrameworkCore.Refactor
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Threading.Tasks;
    using AutoMapper.Extensions.ExpressionMapping.Impl;
    using Collections;
    using Filtering;
    using Remotion.Linq.Parsing.ExpressionVisitors;
    using Sorting;

    public class SourceInjectedQuery<T> : IQuery<T>
    {
        public SourceInjectedQuery(ISourceInjectedQueryable<T> source, Expression<Func<T, object>> keySelector, Expression<Func<object, object, bool>> keyComparer)
            : this(source)
        {
            KeySelector = keySelector;
            KeyComparer = keyComparer;
        }

        protected SourceInjectedQuery(ISourceInjectedQueryable<T> source) => Source = source;

        protected virtual Expression<Func<object, object, bool>> KeyComparer { get; }

        protected virtual Expression<Func<T, object>> KeySelector { get; }

        protected ISourceInjectedQueryable<T> Source { get; }

        public virtual IQuery<dynamic> Select(IEnumerable<string> properties)
            => Select(properties.Select(property => typeof(T).GetProperty(property, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)).ToArray());

        public virtual IQuery<dynamic> Select(PropertyInfo[] properties)
        {
            var assembly = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()), AssemblyBuilderAccess.Run);
            var module = assembly.DefineDynamicModule("DynamicQueryable");
            var type = module.DefineType("Anonymous", TypeAttributes.Public | TypeAttributes.Sealed);
            foreach (var property in properties) type.DefineField(property.Name, property.PropertyType, FieldAttributes.Public);
            var parameter = Expression.Parameter(typeof(T));
            var instance = Expression.New(type.CreateTypeInfo());
            var bindings = properties.Select(property => Expression.Bind(instance.Type.GetField(property.Name), Expression.Property(parameter, property)));
            var body = Expression.MemberInit(instance, bindings);
            var selector = Expression.Lambda(body, parameter);
            var call = Expression.Call(typeof(Queryable), "Select", new[] { parameter.Type, instance.Type }, Source.Expression, selector);
            var query = Source.Provider.CreateQuery<dynamic>(call);
            return new DynamicSourceInjectedQuery((ISourceInjectedQueryable<dynamic>) query);
        }

        public virtual T Single() => Source.Single();

        public virtual Task<T> SingleAsync() => Task.FromResult(Source.Single());

        public virtual IQuery<T> Sort(string field, SortDirection? direction)
            => new SourceInjectedQuery<T>((ISourceInjectedQueryable<T>) Source.SortBy(field, direction), KeySelector, KeyComparer);

        public virtual IQuery<T> Where(Filter predicate)
            => new SourceInjectedQuery<T>((ISourceInjectedQueryable<T>) Source.Where(predicate.ToFilterExpression<T>()), KeySelector, KeyComparer);

        public virtual IQuery<T> WhereHasKey(object key)
        {
            // delegate invocation creates an invalid expression, so we have to rearrange the expression tree
            var value = Expression.Convert(Expression.Constant(key), typeof(object));
            var parameter = Expression.Parameter(Source.ElementType);
            var select = ReplacingExpressionVisitor.Replace(KeySelector.Parameters.Single(), parameter, KeySelector.Body);
            var compare1 = ReplacingExpressionVisitor.Replace(KeyComparer.Parameters.ElementAt(0), select, KeyComparer.Body);
            var compare2 = ReplacingExpressionVisitor.Replace(KeyComparer.Parameters.ElementAt(1), value, compare1);
            var predicate = Expression.Lambda(compare2, parameter);
            var call = Expression.Call(typeof(Queryable), "Where", new[] { parameter.Type }, Source.Expression, predicate);
            var query = Source.Provider.CreateQuery<T>(call);
            return new SourceInjectedQuery<T>((ISourceInjectedQueryable<T>) query, KeySelector, KeyComparer);
        }

        public virtual List<T> ToList() => Source.ToList();

        public virtual Task<List<T>> ToListAsync() => Source.ToAsyncEnumerable().ToList();

        public Page<T> ToPage(int offset, int limit)
        {
            var count = Source.Count();
            var items = Source.Skip(offset).Take(limit).ToList();
            return new Page<T>(offset / limit, limit, count, items);
        }

        public async Task<Page<T>> ToPageAsync(int offset, int limit)
        {
            var count = Source.Count();
            var items = Source.Skip(offset).Take(limit).ToAsyncEnumerable().ToList();
            return new Page<T>(offset / limit, limit, count, await items);
        }

        #region IQuery<T>

        IList<T> IQuery<T>.ToList() => ToList();

        async Task<IList<T>> IQuery<T>.ToListAsync() => await ToListAsync();

        IPage<T> IQuery<T>.ToPage(int offset, int limit) => ToPage(offset, limit);

        async Task<IPage<T>> IQuery<T>.ToPageAsync(int offset, int limit) => await ToPageAsync(offset, limit);

        #endregion

        #region IQuery

        IQuery IQuery.Sort(string field, SortDirection? direction) => Sort(field, direction);

        object IQuery.Single() => Single();

        async Task<object> IQuery.SingleAsync() => await SingleAsync();

        IList IQuery.ToList() => ToList();

        async Task<IList> IQuery.ToListAsync() => await ToListAsync();

        IPage IQuery.ToPage(int offset, int limit) => ToPage(offset, limit);

        async Task<IPage> IQuery.ToPageAsync(int offset, int limit) => await ToPageAsync(offset, limit);

        IQuery IQuery.Where(Filter filter) => Where(filter);

        IQuery IQuery.WhereHasKey(object key) => WhereHasKey(key);

        #endregion
    }
}