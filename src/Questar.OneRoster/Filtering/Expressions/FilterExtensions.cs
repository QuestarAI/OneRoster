namespace Questar.OneRoster.Filtering.Expressions
{
    public static class FilterExtensions
    {
        public static FilterExpression<T> ToFilterExpression<T>(this Filter filter)
        {
            return FilterExpression<T>.Parse(filter);
        }
    }
}