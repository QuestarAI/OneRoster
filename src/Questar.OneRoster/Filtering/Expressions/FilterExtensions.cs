namespace Questar.OneRoster.Filtering.Expressions
{
    public static class FilterExtensions
    {
        public static FilterExpression<T> ToFilterExpression<T>(this Filter filter)
        {
            var builder = new FilterExpressionBuilder<T>();
            filter.Accept(builder);
            return builder.ToFilterExpression();
        }
    }
}