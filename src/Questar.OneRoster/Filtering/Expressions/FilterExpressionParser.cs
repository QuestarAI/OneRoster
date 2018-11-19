//namespace Questar.OneRoster.Filtering
//{
//    using System;
//    using System.Collections;
//    using System.Collections.Generic;
//    using System.Linq.Expressions;
//    using System.Reflection;
//    using System.Text.RegularExpressions;
//    using Expressions;
//    using Reflection;

//    internal sealed class FilterExpressionParser
//    {
//        private static readonly Regex Predicate = new Regex(@"(?<Path>[A-Za-z0-9_\.]+)(?<Predicate>!=|=|>=|>|<=|<|~)(?<Value>.+)", RegexOptions.Compiled);

//        private static readonly Regex Logical = new Regex(@"(?<Left>.+)\s+(?<Logical>AND|OR)\s+(?<Right>.+)", RegexOptions.Compiled);

//        private static readonly Regex Scalar = new Regex(@"'(?<Scalar>[^']*)'", RegexOptions.Compiled);

//        private static readonly Regex Vector = new Regex(@"(?<Vector>[^']*)", RegexOptions.Compiled);

//        private static Expression ConvertValueToScalar(string value, PropertyInfo property)
//        {
//            var converter = property.GetConverter();
//            if (converter == null)
//                throw new InvalidOperationException($"Couldn't find type converter for property '{property.Name}' on type '{property.DeclaringType}'.");
//            return Expression.Constant(converter.ConvertFromString(value));
//        }

//        private static Expression ConvertValueToVector(string value, PropertyInfo property)
//        {
//            var type = property.PropertyType.GetItemType();
//            var converter = type.GetConverter();
//            if (converter == null)
//                throw new InvalidOperationException($"Couldn't find type converter for property '{property.Name}' on type '{property.DeclaringType}'.");
//            var values = value.Split(',');
//            var vector = Array.CreateInstance(type, values.Length);
//            for (var index = 0; index < values.Length; index++) vector.SetValue(converter.ConvertFromString(values[index]), index);
//            return Expression.Constant(vector);
//        }

//        private static MemberExpression GetProperty(string path, Type type, Expression instance)
//        {
//            var properties = new Queue<PropertyInfo>();
//            foreach (var name in path.Split('.'))
//            {
//                var property = type.GetProperty(name);
//                if (property == null) throw new InvalidOperationException($"Couldn't determine path '{path}' from type '${type}'.");
//                type = property.PropertyType;
//                properties.Enqueue(property);
//            }

//            while (properties.TryDequeue(out var property))
//                instance = Expression.Property(instance, property);
//            return instance as MemberExpression;
//        }

//        private static Expression GetValue(string value, PropertyInfo property)
//        {
//            var scalar = Scalar.Match(value);
//            if (scalar.Success)
//                return ConvertValueToScalar(scalar.Groups["Scalar"].Value, property);
//            var vector = Vector.Match(value);
//            if (vector.Success)
//                return ConvertValueToVector(vector.Groups["Vector"].Value, property);
//            throw new InvalidOperationException($"Couldn't convert value '{value}' to type '{property.PropertyType}'");
//        }

//        private static Expression GetContains(MethodInfo method, Expression property, Expression value)
//        {
//            var itemType = property.Type.GetItemType();
//            var item = Expression.Parameter(itemType, "item");
//            var contains = Expression.Lambda(Expression.Call(null, FilterInfo.Contains.MakeGenericMethod(itemType), property, item), item);
//            return Expression.Call(null, method.MakeGenericMethod(itemType), value, contains);
//        }

//        public FilterExpression<T> Parse<T>(string filter) => new FilterExpression<T>((Expression<Func<T, bool>>)Parse(filter, Expression.Parameter(typeof(T), "source")));

//        private static LambdaExpression Parse(string filter, ParameterExpression parameter) => Expression.Lambda(Parse(filter, parameter.Type, parameter), parameter);
        
//        private static Expression Parse(string filter, Type type, Expression instance) =>
//            ParseLogical(filter, type, instance) ??
//            ParsePredicate(filter, type, instance) ??
//            throw new InvalidOperationException($"Couldn't parse filter '{filter}'.");

//        private static Expression ParseLogical(string filter, Type type, Expression instance)
//        {
//            var match = Logical.Match(filter);
//            if (!match.Success)
//                return null;
//            var left = Parse(match.Groups["Left"].Value, type, instance);
//            var logical = match.Groups["Logical"].Value;
//            var right = Parse(match.Groups["Right"].Value, type, instance);
//            switch (logical)
//            {
//                case "AND":
//                    return Expression.AndAlso(left, right);
//                case "OR":
//                    return Expression.OrElse(left, right);
//                default:
//                    throw new InvalidOperationException("Logical condition not found.");
//            }
//        }

//        private static Expression ParsePredicate(string filter, Type type, Expression instance)
//        {
//            var match = Predicate.Match(filter);
//            if (!match.Success)
//                return null;
//            var property = GetProperty(match.Groups["Path"].Value, type, instance);
//            var predicate = match.Groups["Predicate"].Value;
//            var value = GetValue(match.Groups["Value"].Value, (PropertyInfo) property.Member);
//            if (typeof(ICollection).IsAssignableFrom(property.Type))
//                switch (predicate)
//                {
//                    case "=":
//                        return GetContains(FilterInfo.All, property, value);
//                    case "~":
//                        return GetContains(FilterInfo.Any, property, value);
//                    default:
//                        throw new InvalidOperationException("Predicate condition not found.");
//                }
//            switch (predicate)
//            {
//                case "=":
//                    return Expression.Equal(property, value);
//                case "!=":
//                    return Expression.NotEqual(property, value);
//                case ">":
//                    return Expression.GreaterThan(property, value);
//                case ">=":
//                    return Expression.GreaterThanOrEqual(property, value);
//                case "<":
//                    return Expression.LessThan(property, value);
//                case "<=":
//                    return Expression.LessThanOrEqual(property, value);
//                default:
//                    throw new InvalidOperationException("Predicate condition not found.");
//            }
//        }
//    }
//}