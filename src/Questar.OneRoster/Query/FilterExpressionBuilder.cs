namespace Questar.OneRoster.Query
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Common;
    using Exceptions;

    public class FilterExpressionBuilder<T>
    {
        internal static Type Type => ReflectionCache<T>.Type;
        internal static Dictionary<string, Type> PropertyTypesByName => ReflectionCache<T>.PropertyTypesByName;
        internal static IList<string> PropertyNames => ReflectionCache<T>.PropertyNames;

        public static Expression<Func<T, bool>> FromString(string filterString)
            => string.IsNullOrWhiteSpace(filterString)
                ? null
                : FromFilters(FilterParser.FromString(filterString));

        public static Expression<Func<T, bool>> FromFilters(IList<Filter> filters)
        {
            if (filters == null || !filters.Any()) return null;
            var parameter = Expression.Parameter(Type, "p0");
            var tuples = filters.Select(filter => (filter: filter, expression: BuildFilterExpression(parameter, filter)));
            // TODO: Can I LINQ chain this entire thing..? :-D
            var andGroups = BuildAndGroups(tuples);
            var body = andGroups
                .Select(andGroup => andGroup.Aggregate(Expression.AndAlso))
                .Aggregate(Expression.OrElse);
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
                throw InvalidFieldNameException.FromArgs(filter.FieldName, PropertyNames);
            }
            // Expression.Property actually does a case-insensitive lookup.
            var prop = Expression.Property(param, filter.FieldName);
            if (!CanApplyOperatorToType(filter.Operator, propType))
            {
                // Use the properly cased member name in the exception.
                throw InvalidBinaryOperatorException.FromArgs(filter.Operator, propType, prop.Member.Name);
            }

            var constant = ParseConstant(filter.Value, propType);
            return constant.Type == typeof(InvalidEnum)
                ? Expression.Constant(filter.Operator == BinaryOperator.NotEqual)
                : BuildBinaryExpression(prop, constant, filter.Operator);
        }

        private static bool CanApplyOperatorToType(BinaryOperator op, Type propType)
            => !FilterBuilder.NumericOnlyOperators.Contains(op)
               ||  FilterBuilder.NumericTypes.Contains(propType);

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
                default: throw BinaryOperatorOutOfRangeException.FromArgs(op);
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
            if (propType == typeof(DateTime)) return Expression.Constant(Iso8601.Parse(value));
            if (propType == typeof(Guid)) return Expression.Constant(Guid.Parse(value));
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

            throw NotSupportedTypeException.FromArgs(propType);
        }

        private enum InvalidEnum
        {
            NonExistent,
        };
    }
}