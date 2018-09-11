namespace Questar.OneRoster.Data.Extensions
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Paging;

    public static class Pagination
    {
        public static async Task<Page<TSource>> ToPageAsync<TSource>(this IOrderedQueryable<TSource> queryable, int index, int size)
        {
            Debug.Assert(index >= 0, $"{nameof(index)} must be greater than or equal to 0");
            Debug.Assert(size > 0, $"{nameof(size)} must be greater than 0");

            var count = await queryable.CountAsync();
            var items = queryable.Skip(index * size).Take(size);

            return new Page<TSource>(index, size, count, items);
        }

        public static async Task<Page<TResult>> ToPageAsync<TSource, TResult>(this IOrderedQueryable<TSource> queryable, int index, int size, Func<TSource, TResult> resultSelector)
        {
            Debug.Assert(index >= 0, $"{nameof(index)} must be greater than or equal to 0");
            Debug.Assert(size > 0, $"{nameof(size)} must be greater than 0");

            var count = await queryable.CountAsync();
            var items = queryable.Skip(index * size).Take(size).AsEnumerable().Select(resultSelector);

            return new Page<TResult>(index, size, count, items);
        }
    }
}