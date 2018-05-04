namespace Questar.OneRoster.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Model.Common;

    public class OrderedQueryable<TElement> : IOrderedQueryable<TElement>
    {
        private readonly GuidType _guidType;
        private readonly ObjectType _objectType;

        public Type ElementType => typeof(TElement);
        public Expression Expression { get; }
        public IQueryProvider Provider { get; }

        public OrderedQueryable(GuidType guidType)
        {
            _guidType = guidType;
            _objectType = guidType.ToObjectType();
            Provider = new QueryProvider<TElement>(_guidType, _objectType);
            Expression = Expression.Constant(this);
        }

        public IEnumerator<TElement> GetEnumerator()
            => Provider.Execute<IEnumerable<TElement>>(Expression).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class QueryProvider<T> : IQueryProvider
    {
        private readonly GuidType _guidType;
        private readonly ObjectType _objectType;

        public QueryProvider(GuidType guidType, ObjectType objectType)
        {
            _guidType = guidType;
            _objectType = objectType;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            throw new NotImplementedException();
        }

        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}