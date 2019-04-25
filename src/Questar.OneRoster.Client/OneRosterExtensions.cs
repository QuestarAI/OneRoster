namespace Questar.OneRoster.Client
{
    using System;
    using System.Linq;

    public static class OneRosterExtensions
    {
        public static OneRosterQueryResult<T> ToOneRosterQueryResult<T>(this IQueryable<T> queryable)
            => (queryable as IOneRosterQueryResultProvider<T>)?.GetQueryResult() ?? throw new InvalidOperationException();

        public static OneRosterQueryResult<T> Output<T, TOutput>(this IQueryable<T> queryable, out TOutput output)
           => throw new NotImplementedException();
    }
}