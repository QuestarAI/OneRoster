namespace Questar.OneRoster.Filtering.Expressions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Reflection;

    public sealed class FilterValueBuilder : ExpressionVisitor
    {
        public FilterValueBuilder() : this(null)
        {
        }

        public FilterValueBuilder(Expression expression)
            => Expression = expression;

        public Expression Expression { get; }

        public FilterValue Value { get; private set; }

        public override Expression Visit(Expression node)
        {
            if (IsTerminal(node)) return node;

            switch (node.NodeType)
            {
                case ExpressionType.Constant:
                case ExpressionType.MemberAccess:
                case ExpressionType.NewArrayInit:
                    return base.Visit(node);
                default:
                    throw new InvalidOperationException($"Invalid expression '{node}'.");
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
            var type = value.GetType();
            var converter = value.GetType().GetConverter();
            if (converter == null)
                throw new InvalidOperationException($"Couldn't find type converter for type '{type}'");
            return converter.ConvertToString(value);
        }

        private string FormatVector(object value)
        {
            var collection = value.GetType().Name != typeof(ICollection<>).Name
                ? value.GetType().GetInterface(typeof(ICollection<>).Name)
                : value.GetType();
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

        protected override Expression VisitMember(MemberExpression node)
        {
            var value = Evaluate(node);
            Value = value is ICollection
                ? new FilterValue(FilterValueType.Vector, FormatVector(value))
                : new FilterValue(FilterValueType.Scalar, FormatScalar(value));
            return node;
        }

        protected override Expression VisitNewArray(NewArrayExpression node)
        {
            Value = new FilterValue(FilterValueType.Vector, FormatVector(Evaluate(node)));
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Value = new FilterValue(FilterValueType.Scalar, FormatScalar(Evaluate(node)));
            return node;
        }
    }
}