namespace Questar.OneRoster.Filtering.Expressions
{
    using System;
    using System.Linq.Expressions;

    public static class FilterExtensions
    {
        public static FilterExpression<T> ToFilterExpression<T>(this Filter filter)
        {
            var builder = new FilterExpressionBuilder(typeof(T));
            filter.Accept(builder);
            return (Expression<Func<T, bool>>) builder.ToExpression();
        }
    }
}