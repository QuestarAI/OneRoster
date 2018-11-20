namespace Questar.OneRoster.Filtering.Expressions
{
    using System;
    using System.Linq.Expressions;

    public class FilterExpressionFactory
    {
        public FilterExpression<T> Create<T>(Filter filter)
            => (Expression<Func<T, bool>>) Create(filter, typeof(T));

        public LambdaExpression Create(Filter filter, Type type)
        {
            var builder = new FilterExpressionBuilder(type, this);
            var visitor = new FilterExpressionFilterVisitor(builder);
            filter.Visit(visitor);
            return builder.ToFilterExpression();
        }
    }
}