using System.Collections.Generic;
using System.Reflection;

namespace Questar.OneRoster.Query
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class FilterExpressionBuilder<T>
    {
        private static readonly Type Type = typeof(T);
        private static readonly Dictionary<string, Type> PropertyTypesByName = typeof(T)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .ToDictionary(p => p.Name, p => p.PropertyType, StringComparer.OrdinalIgnoreCase);

        public static Expression<Func<T, bool>> FromString(string filterString)
        {
            if (string.IsNullOrWhiteSpace(filterString)) return null;
            var parameter = Expression.Parameter(Type, "p0");
            var tuples = FilterParser
                .FromString(filterString)
                .Select(filter => (filter: filter, expression: BuildFilterExpression(parameter, filter)));
            // TODO: Can I LINQ chain this entire thing..? :-D
            var andGroups = BuildAndGroups(tuples);
            var body = andGroups
                .Select(andGroup => andGroup.Aggregate(Expression.And))
                .Aggregate(Expression.Or);
            return BuildFunc(body, parameter);
        }

        private static List<List<Expression>> BuildAndGroups(IEnumerable<(Filter filter, Expression expression)> tuples)
        {
            var currentAndGroup = new List<Expression>();
            var andGroups = new List<List<Expression>> { currentAndGroup };
            var uninitialized = true;
            foreach (var tuple in tuples)
            {
                if (uninitialized)
                {
                    uninitialized = false;
                    currentAndGroup.Add(tuple.expression);
                    continue;
                }
                if (tuple.filter.AndOr == Logical.Or)
                {
                    currentAndGroup = new List<Expression>();
                    andGroups.Add(currentAndGroup);
                }
                currentAndGroup.Add(tuple.expression);
            }
            return andGroups;
        }

        private static Expression<Func<T, bool>> BuildFunc(Expression body, ParameterExpression parameter)
            => Expression.Lambda<Func<T, bool>>(body, false, parameter);

        private static Expression BuildBody(IList<Expression> filterExpressions)
        {
            var body = filterExpressions.First();
            return body;
        }

        private static Expression BuildFilterExpression(Expression param, Filter filter)
        {
            if (!PropertyTypesByName.TryGetValue(filter.FieldName, out var propType))
            {
                throw new InvalidOperationException("TODO: Custom exception.");
            }
            var prop = Expression.Property(param, filter.FieldName);
            var constant = ParseConstant(filter.Value, propType);
            return BuildBinaryExpression(prop, constant, filter.Operator);
        }

        private static Expression BuildBinaryExpression(Expression left, Expression right, string op)
        {
            switch (op)
            {
                case "=": return Expression.Equal(left, right);
                case "!=": return Expression.NotEqual(left, right);
                case ">": return Expression.GreaterThan(left, right);
                case ">=": return Expression.GreaterThanOrEqual(left, right);
                case "<": return Expression.LessThan(left, right);
                case "<=": return Expression.LessThanOrEqual(left, right);
                case "~": return BuildContainsExpression(left, right);
                default: throw new InvalidOperationException("TODO: Custom exception.");
            }
        }

        private static Expression BuildContainsExpression(Expression left, Expression right)
        {
            throw new NotImplementedException();
        }

        private static Expression ParseConstant(string value, Type propType)
        {
            if (propType == typeof(string)) return Expression.Constant(value);
            if (propType == typeof(int)) return Expression.Constant(int.Parse(value));
            throw new NotSupportedException($"Unable to build filter for type {propType.FullName}.");
        }
    }
}