namespace Questar.OneRoster.Api.Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Query;
    using RequestModels;

    public static class DbSetExtensions
    {
        private const BindingFlags PropFlags = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;

        public static async Task<IEnumerable<object>> ToListAsync<T>(this DbSet<T> dbSet, CollectionEndpointRequest<T> request) where T : class
            => await dbSet
            .HandleFilter(request)
            .HandleOrder(request)
            .HandleSkip(request)
            .HandleTake(request)
            .HandleProjection(request);

        private static IQueryable<T> HandleFilter<T>(this IQueryable<T> query, CollectionEndpointRequest<T> request) where T : class
        {
            var predicate = request.BuildPredicate();
            return predicate == null ? query : query.Where(predicate);
        }
        
        private static IQueryable<T> HandleOrder<T>(this IQueryable<T> query, CollectionEndpointRequest<T> request) where T : class
            => string.IsNullOrWhiteSpace(request.Sort)
                ? query
                : request.OrderBy == null || request.OrderBy == SortDirection.Asc
                    ? query.OrderBy(SelectProperty<T>(request.Sort))
                    : query.OrderByDescending(SelectProperty<T>(request.Sort));
        
        private static IQueryable<T> HandleSkip<T>(this IQueryable<T> query, CollectionEndpointRequest<T> request) where T : class
            => request.Offset > 0
                ? query.Skip(request.Offset)
                : query;

        private static IQueryable<T> HandleTake<T>(this IQueryable<T> query, CollectionEndpointRequest<T> request) where T : class
            => request.Limit > 0
                ? query.Take(request.Limit)
                : query;

        private static async Task<IEnumerable<object>> HandleProjection<T>(this IQueryable<T> query, CollectionEndpointRequest<T> request) where T : class
        {
            if (string.IsNullOrWhiteSpace(request.Fields))
            {
                return await query.ToListAsync();
            }

            var fields = request.Fields
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(field => field.Trim())
                .ToList();

            var projected = await query.Select<T>(fields).ToListAsync();
            return projected.ToExpandoObjects(fields);
        }

        private static IEnumerable<ExpandoObject> ToExpandoObjects<T>(this IEnumerable<T> projected, IEnumerable<string> fields) where T : class
            => projected.Select(obj =>
            {
                var exp = new ExpandoObject();
                var dict = (IDictionary<string, object>)exp;

                foreach (var field in fields)
                {
                    // TODO: Caching...
                    dict[field] = obj.GetType().GetProperty(field, PropFlags).GetValue(obj);
                }

                return exp;
            });

        private static Expression<Func<T, object>> SelectProperty<T>(string property)
        {
            var type = typeof(T);
            var parameter = Expression.Parameter(type, "e");
            var prop = Expression.Property(parameter, property);
            var body = prop.Type.IsValueType
                ? (Expression) Expression.Convert(prop, typeof(object))
                : prop;
            return Expression.Lambda<Func<T, object>>(body, parameter);
        }

        private static IQueryable<TResult> Select<TResult>(this IQueryable source, IEnumerable<string> columns)
        {
            var sourceType = source.ElementType;
            var resultType = typeof(TResult);
            var parameter = Expression.Parameter(sourceType, "e");
            var bindings = columns.Select(column => Expression.Bind(resultType.GetProperty(column, PropFlags), Expression.Property(parameter, column)));
            var body = Expression.MemberInit(Expression.New(resultType), bindings);
            var selector = Expression.Lambda(body, parameter);
            var call = Expression.Call(typeof(Queryable), "Select", new[] { sourceType, resultType }, source.Expression, Expression.Quote(selector));
            return source.Provider.CreateQuery<TResult>(call);
        }
    }
}