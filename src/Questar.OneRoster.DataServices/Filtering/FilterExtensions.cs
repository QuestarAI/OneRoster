using System;
using System.Linq.Expressions;
using Questar.OneRoster.Filtering;

namespace Questar.OneRoster.DataServices.Filtering
{
    public static class FilterExtensions
    {
        public static IQuery<T> Where<T>(this IQuery<T> query, Expression<Func<T, bool>> predicate)
        {
            return query.Where(new FilterExpression<T>(predicate));
        }

        public static IQuery<T> Where<T>(this IQuery<T> query, FilterExpression<T> predicate)
        {
            return query.Where(predicate.ToFilter());
        }
    }
}