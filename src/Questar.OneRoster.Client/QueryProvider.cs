namespace Questar.OneRoster.Client
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class QueryProvider<T> : IQueryProvider
    {
        public IQueryable CreateQuery(Expression expression) => throw new NotImplementedException();

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) => throw new NotImplementedException();

        public object Execute(Expression expression) => throw new NotImplementedException();

        public TResult Execute<TResult>(Expression expression) => throw new NotImplementedException();
    }
}