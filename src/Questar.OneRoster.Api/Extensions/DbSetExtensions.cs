namespace Questar.OneRoster.Api.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Query;
    using RequestModels;

    public static class DbSetExtensions
    {
        public static Task<List<T>> ToListAsync<T>(this DbSet<T> dbSet, CollectionEndpointRequest<T> request) where T : class
        {
            IQueryable<T> query = dbSet;

            var predicate = request.BuildPredicate();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            // TODO: Implement this conversion.
            if (!string.IsNullOrWhiteSpace(request.Sort))
            {
                query = request.OrderBy == SortDirection.Asc
                    ? query.OrderBy(session => request.Sort)
                    : query.OrderByDescending(session => request.Sort);
            }

            if (request.Offset > 0)
            {
                query = query.Skip(request.Offset);
            }

            if (request.Limit != 0)
            {
                query = query.Take(request.Limit);
            }

            return query.ToListAsync();
        }
    }
}