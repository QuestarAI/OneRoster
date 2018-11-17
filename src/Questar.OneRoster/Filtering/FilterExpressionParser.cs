namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text.RegularExpressions;

    internal sealed class FilterExpressionParser
    {
        private static readonly Regex Predicate = new Regex(@"(?<Path>[A-Za-z0-9_\.]+)(?<Predicate>!=|=|>=|>|<=|<|~)(?<Value>.+)", RegexOptions.Compiled);

        private static readonly Regex Logical = new Regex(@"(?<Left>.+)\s+(?<Logical>AND|OR)\s+(?<Right>.+)", RegexOptions.Compiled);

        private static readonly Regex Scalar = new Regex(@"'(?<Scalar>[^']*)'", RegexOptions.Compiled);

        private static readonly Regex Vector = new Regex(@"(?<Vector>[^']*)", RegexOptions.Compiled);

        private static object ConvertValueToScalar(string value, Type type)
        {
            // TODO pass in and use a... converter interface? is there a built-in one?

            return type.IsEnum
                ? Enum.TryParse(type, value, out var @enum)
                    ? @enum
                    : Convert.ChangeType(value, type)
                : typeof(IConvertible).IsAssignableFrom(type)
                    ? Convert.ChangeType(value, type)
                    : Activator.CreateInstance(type, value);
        }

        private static Expression ConvertValueToVector(string value, Type type)
        {
            var values = value.Split(',');
            var vector = Array.CreateInstance(type, values.Length);

            for (var index = 0; index < values.Length; index++) vector.SetValue(ConvertValueToScalar(values[index], type), index);

            return Expression.Constant(vector);
        }

        private static MemberExpression GetProperty(string path, Type type, Expression instance)
        {
            var properties = new Queue<PropertyInfo>();

            foreach (var name in path.Split('.'))
            {
                var property = type.GetProperty(name);
                if (property == null) throw new InvalidOperationException($"Couldn't determine path '{path}' from type '${type}'.");

                type = property.PropertyType;

                properties.Enqueue(property);
            }

            while (properties.TryDequeue(out var property))
                instance = Expression.Property(instance, property);

            return instance as MemberExpression;
        }

        private static Expression GetValue(string value, Type type)
        {
            var scalar = Scalar.Match(value);
            if (scalar.Success)
                return Expression.Constant(ConvertValueToScalar(scalar.Groups["Scalar"].Value, type));

            var vector = Vector.Match(value);
            if (vector.Success)
                return Expression.Constant(ConvertValueToVector(vector.Groups["Vector"].Value, type));

            throw new InvalidOperationException($"Couldn't convert value '{value}' to type '{type}'");
        }

        private static LambdaExpression Parse(string filter, ParameterExpression parameter)
        {
            return Expression.Lambda(Parse(filter, parameter.Type, parameter), parameter);
        }

        private static Expression Parse(string filter, Type type, Expression instance)
        {
            return ParseLogical(filter, type, instance)
                   ?? ParsePredicate(filter, type, instance)
                   ?? throw new InvalidOperationException($"Couldn't parse filter '{filter}'.");
        }

        private static Expression ParseLogical(string filter, Type type, Expression instance)
        {
            var match = Logical.Match(filter);
            if (!match.Success)
                return null;

            var left = Parse(match.Groups["Left"].Value, type, instance);
            var logical = match.Groups["Logical"].Value;
            var right = Parse(match.Groups["Right"].Value, type, instance);

            switch (logical)
            {
                case "AND":
                    return Expression.AndAlso(left, right);
                case "OR":
                    return Expression.OrElse(left, right);
                default:
                    throw new InvalidOperationException("Logical condition not found.");
            }
        }

        private static Expression ParsePredicate(string filter, Type type, Expression instance)
        {
            var match = Predicate.Match(filter);
            if (!match.Success)
                return null;

            var property = GetProperty(match.Groups["Path"].Value, type, instance);
            var predicate = match.Groups["Predicate"].Value;
            var value = GetValue(match.Groups["Value"].Value, property.Type);

            if (typeof(ICollection).IsAssignableFrom(property.Type))
                switch (predicate)
                {
                    case "=":
                        return Expression.Call(null, FilterInfo.All.MakeGenericMethod(property.Type), value, property);
                    case "~":
                        return Expression.Call(null, FilterInfo.Any.MakeGenericMethod(property.Type), value, property);
                    default:
                        throw new InvalidOperationException("Predicate condition not found.");
                }

            switch (predicate)
            {
                case "=":
                    return Expression.Equal(property, value);
                case "!=":
                    return Expression.NotEqual(property, value);
                case ">":
                    return Expression.GreaterThan(property, value);
                case ">=":
                    return Expression.GreaterThanOrEqual(property, value);
                case "<":
                    return Expression.LessThan(property, value);
                case "<=":
                    return Expression.LessThanOrEqual(property, value);
                default:
                    throw new InvalidOperationException("Predicate condition not found.");
            }
        }

        public FilterExpression<T> Parse<T>(string filter)
        {
            return new FilterExpression<T>((Expression<Func<T, bool>>) Parse(filter, Expression.Parameter(typeof(T), "source")));
        }
    }
}