namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Filtering;
    using Remotion.Linq.Parsing.ExpressionVisitors;
    using Sorting;

    public class Query<T> : IQuery<T>
    {
        public Query(IQueryable<T> source, Expression<Func<T, object>> keySelector, Expression<Func<object, object, bool>> keyComparer)
        {
            Source = source;
            KeySelector = keySelector;
            KeyComparer = keyComparer;
        }

        protected IQueryable<T> Source { get; }

        protected Expression<Func<T, object>> KeySelector { get; }

        protected Expression<Func<object, object, bool>> KeyComparer { get; }

        protected virtual IDynamicQuery ToDynamicQuery(IEnumerable<string> fields) => new DynamicQuery<T>(Source, fields);

        public IDynamicQuery Fields(IEnumerable<string> fields) => ToDynamicQuery(fields);

        public virtual T Single() => Source.Single();

        public virtual Task<T> SingleAsync() => Task.FromResult(Source.Single());

        IList<T> IQuery<T>.ToList() => ToList();

        async Task<IList<T>> IQuery<T>.ToListAsync() => await ToListAsync();

        public virtual IQuery<T> Where(FilterExpression<T> predicate) => new Query<T>(Source.Where(predicate), KeySelector, KeyComparer);

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
            return new Query<T>(query, KeySelector, KeyComparer);
        }

        public virtual IOrderedQuery<T> Sort(string field, SortDirection? direction) => new OrderedQuery<T>(Source.SortBy(field, direction), KeySelector, KeyComparer);

        object IQuery.Single() => Single();

        async Task<object> IQuery.SingleAsync() => await SingleAsync();

        IList IQuery.ToList() => ToList();

        async Task<IList> IQuery.ToListAsync() => await ToListAsync();

        public virtual List<T> ToList() => Source.ToList();

        public virtual Task<List<T>> ToListAsync() => Source.ToAsyncEnumerable().ToList();
    }
}