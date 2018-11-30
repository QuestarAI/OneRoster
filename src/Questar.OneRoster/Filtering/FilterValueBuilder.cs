namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Reflection;

    public sealed class FilterValueBuilder : ExpressionVisitor
    {
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
            return getter();
        }

        private bool IsTerminal(Expression expression)
            => Expression?.Equals(expression) == true;

        private string FormatScalar(object value)
        {
            var property = Property.PropertyType;
            var converter = property.GetConverter();
            if (converter == null)
                throw new InvalidOperationException($"Couldn't find type converter for type '{property}'.");

            // TODO refactor this special case
            // TODO find a better solution for formatting in general...

            return value is DateTime date
                ? date.ToString(date.TimeOfDay.Ticks > 0 ? "yyyy-MM-ddTHH:mm:ss.fffK" : "yyyy-MM-dd")
                : converter.ConvertToString(value);
        }

        private string FormatVector(object value)
        {
            var property = Property.PropertyType;
            var collection = property.Name == typeof(ICollection<>).Name
                ? property
                : property.GetInterface(typeof(ICollection<>).Name);
            if (collection == null)
                throw new InvalidOperationException($"Value '{value}' does not implement '{typeof(ICollection<>).Name}'.");
            var type = collection.GetGenericArguments().Single();
            var converter = type.GetConverter();
            if (converter == null)
                throw new InvalidOperationException($"Couldn't find type converter for type '{type.Name}'.");
            if (value is IEnumerable enumerable)
                return string.Join(",", enumerable.Cast<object>().Select(converter.ConvertToString));
            throw new InvalidOperationException($"Value '{value}' does not implement '{typeof(IEnumerable).Name}'.");
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