namespace Questar.OneRoster.DataServices.Filtering
{
    using System;
    using System.Linq.Expressions;
    using OneRoster.Filtering;

    public static class FilterExtensions
    {
        public static IQuery<T> Where<T>(this IQuery<T> query, Expression<Func<T, bool>> predicate)
            => query.Where(new FilterExpression<T>(predicate));

        public static IQuery<T> Where<T>(this IQuery<T> query, FilterExpression<T> predicate)
            => query.Where(predicate.ToFilter());
    }
}