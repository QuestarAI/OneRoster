namespace Questar.OneRoster.Sorting
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public static class Sort
    {
        internal static readonly MethodInfo Info =
            typeof(Sort)
                .GetMethods()
                .Single(method => method.Name == nameof(SortBy) && method.GetGenericArguments().Length == 2 && method.GetParameters().Length == 3);

        public static IOrderedQueryable<TSource> SortBy<TSource>(this IQueryable<TSource> source, string path, SortDirection? direction = default)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (path == null) throw new ArgumentNullException(nameof(path));

            var names = path.Split('.');
            if (names.Length == 0)
                throw new ArgumentException("A property path must be provided.");

            var type = typeof(TSource);
            var parameter = Expression.Parameter(typeof(TSource));
            var body = (Expression) parameter;

            foreach (var name in names)
            {
                var property = type.GetProperty(name);
                if (property == null)
                    throw new InvalidOperationException($"Couldn't find property '{name}' on type '{type}'.");

                body = Expression.Property(body, property);
                type = property.PropertyType;
            }

            return (IOrderedQueryable<TSource>)
                Info.MakeGenericMethod(typeof(TSource), body.Type)
                    .Invoke(null, new object[] { source, Expression.Lambda(body, parameter), direction });
        }

        public static IOrderedQueryable<TSource> SortBy<TSource, TProperty>(this IQueryable<TSource> source, Expression<Func<TSource, TProperty>> selector, SortDirection? direction = default)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            switch (direction)
            {
                case null:
                case SortDirection.Asc:
                    return source.OrderBy(selector);
                case SortDirection.Desc:
                    return source.OrderByDescending(selector);
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction));
            }
        }
    }
}