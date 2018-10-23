namespace Questar.OneRoster.Api.Extensions
{
    using System;
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

        public static Task<IEnumerable<object>> ToListAsync<T>(this DbSet<T> dbSet, CollectionEndpointContext<T> context) where T : class
            => dbSet
            .HandleFilter(context)
            .HandleOrder(context)
            .HandleSkip(context)
            .HandleTake(context)
            .HandleProjection(context);

        public static Task<int> CountAsync<T>(this DbSet<T> dbSet, CollectionEndpointContext<T> context) where T : class
            => dbSet
            .HandleFilter(context)
            .CountAsync();

        private static IQueryable<T> HandleFilter<T>(this IQueryable<T> query, CollectionEndpointContext<T> context) where T : class
        {
            var predicate = context.GetPredicate();
            return predicate == null ? query : query.Where(predicate);
        }
        
        private static IQueryable<T> HandleOrder<T>(this IQueryable<T> query, CollectionEndpointContext<T> context) where T : class
            => !context.RequestSortIsValid || string.IsNullOrWhiteSpace(context.Request.Sort)
                ? query
                : context.Request.OrderBy == null || context.Request.OrderBy == SortDirection.Asc
                    ? query.OrderBy(SelectProperty<T>(context.Request.Sort))
                    : query.OrderByDescending(SelectProperty<T>(context.Request.Sort));
        
        private static IQueryable<T> HandleSkip<T>(this IQueryable<T> query, CollectionEndpointContext<T> context) where T : class
            => context.Request.Offset > 0
                ? query.Skip(context.Request.Offset)
                : context.Request.Offset == 0
                    ? query
                    : throw new InvalidOperationException("Offset must be greater than or equal to 0.");

        private static IQueryable<T> HandleTake<T>(this IQueryable<T> query, CollectionEndpointContext<T> context) where T : class
            => context.Request.Limit > 0
                ? query.Take(context.Request.Limit)
                : throw new InvalidOperationException("Limit must be greater than 0.");

        private static async Task<IEnumerable<object>> HandleProjection<T>(this IQueryable<T> query, CollectionEndpointContext<T> context) where T : class
        {
            if (string.IsNullOrWhiteSpace(context.Request.Fields))
            {
                return await query.ToListAsync();
            }

            var projection = Projections<T>.FromFields(context.Request.Fields);

            // Optimization; no need for projection; OneRoster spec requires all fields returned in this case.
            if (projection.NonexistentFields.Any())
            {
                return await query.ToListAsync();
            }

            var incompleteObjects = await query.Select<T>(projection.ExistentFields).ToListAsync();
            return projection.Apply(incompleteObjects);
        }

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

        private static class Projections<T>
        {
            private static readonly IDictionary<string, Projection<T>> Cache = new Dictionary<string, Projection<T>>(StringComparer.OrdinalIgnoreCase);

            public static Projection<T> FromFields(string fields)
            {
                if (Cache.TryGetValue(fields, out var projection)) return projection;

                var fieldList = fields
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(field => field.Trim())
                    .ToList();
                
                Cache[fields] = projection = new Projection<T>(fieldList);
                return projection;
            }
        }

        private class Projection<T>
        {
            private static readonly Type Type = typeof(T);
            private static readonly Dictionary<string, PropertyInfo> Properties
                = Type.GetProperties(PropFlags).ToDictionary(p => p.Name, p => p, StringComparer.OrdinalIgnoreCase);

            private static readonly IEnumerable<string> AllFields = Properties.Keys.ToList();
            
            public Projection(IEnumerable<string> fields)
            {
                CategorizeFields(fields);

                if (NonexistentFields.Any())
                {
                    return;
                }

                _applyDelegate = BuildApplyDelegate();
            }

            private readonly Delegate _applyDelegate;

            public IEnumerable<string> ExistentFields { get; private set; }
            public IEnumerable<string> NonexistentFields { get; private set; }

            public IEnumerable<ExpandoObject> Apply(IEnumerable<T> projected)
            {
                // TODO: Can delegate handle the loop itself?
                foreach (var item in projected)
                {
                    var expando = new ExpandoObject();
                    var dictionary = (IDictionary<string, object>)expando;
                    _applyDelegate.DynamicInvoke(item, dictionary);
                    yield return expando;
                }
            }

            private void CategorizeFields(IEnumerable<string> fields)
            {
                var existentFields = new List<string>();
                var nonexistentFields = new List<string>();
                foreach (var field in fields)
                {
                    var list = Properties.ContainsKey(field)
                        ? existentFields
                        : nonexistentFields;
                    list.Add(field);
                }

                ExistentFields = existentFields;
                NonexistentFields = nonexistentFields;
            }

            private Delegate BuildApplyDelegate()
            {
                var itemParam = Expression.Parameter(typeof(T), "item");
                var dictionaryParam = Expression.Parameter(typeof(IDictionary<string, object>), "dict");
                
                var assignments = new List<Expression>();
                foreach (var field in ExistentFields)
                {
                    var dictionaryKeyProperty = Expression.Property(dictionaryParam, "Item", Expression.Constant(field));
                    var itemProperty = Expression.Property(itemParam, field);
                    var right = itemProperty.Type.IsValueType
                        ? (Expression) Expression.Convert(itemProperty, typeof(object))
                        : itemProperty;
                    var assign = Expression.Assign(dictionaryKeyProperty, right);
                    assignments.Add(assign);
                }

                var body = Expression.Block(assignments);
                var func = Expression.Lambda(body, itemParam, dictionaryParam);
                return func.Compile();
            }
        }
    }
}