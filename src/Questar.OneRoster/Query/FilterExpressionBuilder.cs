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
            foreach (var (filter, expression) in tuples)
            {
                if (filter.AndOr == LogicalOperator.Or)
                {
                    currentAndGroup = new List<Expression>();
                    andGroups.Add(currentAndGroup);
                }
                currentAndGroup.Add(expression);
            }
            return andGroups;
        }

        private static Expression<Func<T, bool>> BuildFunc(Expression body, ParameterExpression parameter)
            => Expression.Lambda<Func<T, bool>>(body, false, parameter);

        private static Expression BuildFilterExpression(Expression param, Filter filter)
        {
            if (!PropertyTypesByName.TryGetValue(filter.FieldName, out var propType))
            {
                throw new InvalidOperationException("TODO: Custom exception.");
            }
            Expression prop = Expression.Property(param, filter.FieldName);
            var constant = ParseConstant(filter.Value, propType);
            if (constant.Type != typeof(InvalidEnum))
            {
                return BuildBinaryExpression(prop, constant, filter.Operator);
            }
            switch (filter.Operator)
            {
                case BinaryOperator.Equal: return Expression.Constant(false);
                case BinaryOperator.NotEqual: return Expression.Constant(true);
                default: return BuildBinaryExpression(prop, constant, filter.Operator);
            }
        }

        private static Expression BuildBinaryExpression(Expression left, Expression right, BinaryOperator op)
        {
            switch (op)
            {
                case BinaryOperator.Equal: return Expression.Equal(left, right);
                case BinaryOperator.NotEqual: return Expression.NotEqual(left, right);
                case BinaryOperator.GreaterThan: return Expression.GreaterThan(left, right);
                case BinaryOperator.GreaterThanOrEqual: return Expression.GreaterThanOrEqual(left, right);
                case BinaryOperator.LessThan: return Expression.LessThan(left, right);
                case BinaryOperator.LessThanOrEqual: return Expression.LessThanOrEqual(left, right);
                case BinaryOperator.Contains: return BuildContainsExpression(left, right);
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
            if (propType.IsEnum)
            {
                try
                {
                    return Expression.Constant(Enum.Parse(propType, value, true));
                }
                catch (Exception)
                {
                    return Expression.Constant(InvalidEnum.NonExistent);
                }
            }

            throw new NotSupportedException($"Unable to build filter for type {propType.FullName}.");
        }

        private enum InvalidEnum
        {
            NonExistent
        };
    }
}