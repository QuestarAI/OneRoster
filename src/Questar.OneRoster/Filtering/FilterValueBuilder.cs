namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Common;
    using Reflection;

    public sealed class FilterValueBuilder : ExpressionVisitor
    {
        public FilterValueBuilder(PropertyInfo property)
            : this(property, null)
        {
        }

        public FilterValueBuilder(PropertyInfo property, Expression expression)
        {
            Property = property;
            Expression = expression;
        }

        public Expression Expression { get; }

        public PropertyInfo Property { get; }

        public FilterValue Value { get; private set; }

        public override Expression Visit(Expression node)
        {
            if (IsTerminal(node)) return node;

            switch (node.NodeType)
            {
                case ExpressionType.Constant:
                    return base.Visit(node);
                default:
                    Value = GetValue(Evaluate(node));
                    return node;
            }
        }

        private static object Evaluate(Expression node)
        {
            var convert = Expression.Convert(node, typeof(object));
            var lambda = Expression.Lambda<Func<object>>(convert);
            var getter = lambda.Compile();
            var value = getter();
            return value;
        }

        private bool IsTerminal(Expression expression)
            => Expression?.Equals(expression) == true;

        private string FormatScalar(object value)
        {
            var property = Property.PropertyType;
            var converter = property.GetConverter();
            if (converter == null)
                throw new InvalidOperationException($"Couldn't find type converter for type '{property}'");

            // TODO find a better solution for formatting in general...

            if (value is DateTime date)
                return date.ToString(date.TimeOfDay.Ticks > 0 ? "yyyy-MM-ddTHH:mm:ss.fffK" : "yyyy-MM-dd" /*, new IsoDateTimeFormatInfo() */);
            else
                return converter.ConvertToString(value);
        }

        private string FormatVector(object value)
        {
            var property = Property.PropertyType;
            var collection = property.Name != typeof(ICollection<>).Name
                ? property.GetInterface(typeof(ICollection<>).Name)
                : property;
            if (collection == null)
                throw new InvalidOperationException($"Value '{value}' is not of type '{typeof(ICollection<>)}'.");
            var type = collection.GetGenericArguments().Single();
            var converter = type.GetConverter();
            if (converter == null)
                throw new InvalidOperationException($"Couldn't find type converter for type '{type}'");
            if (value is IEnumerable enumerable)
                return string.Join(',', enumerable.Cast<object>().Select(converter.ConvertToString));
            throw new InvalidOperationException($"Value '{value}' is not of type '{typeof(IEnumerable)}'.");
        }

        private FilterValue GetValue(object value)
            => value is ICollection
                ? new FilterValue(FilterValueType.Vector, FormatVector(value))
                : new FilterValue(FilterValueType.Scalar, FormatScalar(value));

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Value = GetValue(node.Value);
            return node;
        }
    }
}