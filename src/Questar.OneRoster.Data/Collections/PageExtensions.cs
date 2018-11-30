namespace Questar.OneRoster.Data.Collections
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public static class Pagination
    {
        public static async Task<Page<TSource>> ToPageAsync<TSource>(this IOrderedQueryable<TSource> queryable, int index, int size)
        {
            Debug.Assert(index >= 0, $"{nameof(index)} must be greater than or equal to 0.");
            Debug.Assert(size > 0, $"{nameof(size)} must be greater than 0.");

            var count = queryable.CountAsync();
            var items = queryable.Skip(index * size).Take(size).ToListAsync();

            return new Page<TSource>(index, size, await count, await items);
        }

        public static async Task<Page<TResult>> ToPageAsync<TSource, TResult>(
            this IOrderedQueryable<TSource> queryable,
            int index,
            int size,
            Expression<Func<TSource, TResult>> resultSelector)
        {
            Debug.Assert(index >= 0, $"{nameof(index)} must be greater than or equal to 0.");
            Debug.Assert(size > 0, $"{nameof(size)} must be greater than 0.");

            var count = queryable.CountAsync();
            var items = queryable.Skip(index * size).Take(size).Select(resultSelector).ToListAsync();

            return new Page<TResult>(index, size, await count, await items);
        }
    }
}