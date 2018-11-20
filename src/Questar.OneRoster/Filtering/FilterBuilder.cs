namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public sealed class FilterBuilder<T> : ExpressionVisitor
    {
        private readonly Dictionary<ExpressionType, Func<Expression, Expression, FilterBuilder<T>>> _binary;

        private readonly Dictionary<MethodInfo, Func<Expression, Expression, FilterBuilder<T>>> _call;

        private readonly Stack<Filter> _filters = new Stack<Filter>();

        public FilterBuilder()
        {
            _call = new Dictionary<MethodInfo, Func<Expression, Expression, FilterBuilder<T>>>
            {
                { FilterInfo.All, All },
                { FilterInfo.Any, Any }
            };
            _binary = new Dictionary<ExpressionType, Func<Expression, Expression, FilterBuilder<T>>>
            {
                { ExpressionType.AndAlso, AndAlso },
                { ExpressionType.Equal, Equal },
                { ExpressionType.GreaterThan, GreaterThan },
                { ExpressionType.GreaterThanOrEqual, GreaterThanOrEqual },
                { ExpressionType.LessThan, LessThan },
                { ExpressionType.LessThanOrEqual, LessThanOrEqual },
                { ExpressionType.NotEqual, NotEqual },
                { ExpressionType.OrElse, OrElse }
            };
        }

        public FilterBuilder(Expression expression) : this()
            => Expression = expression;

        public Expression Expression { get; }

        public FilterBuilder<T> AndAlso(Expression left, Expression right)
            => Logical(left, LogicalOperator.And, right);

        public FilterBuilder<T> Any(Expression property, Expression value)
            => Predicate(property, PredicateOperator.Contains, value);

        public FilterBuilder<T> All(Expression property, Expression value)
            => Predicate(property, PredicateOperator.Equal, value);

        public FilterBuilder<T> Equal(Expression property, Expression value)
            => Predicate(property, PredicateOperator.Equal, value);

        public FilterBuilder<T> GreaterThan(Expression property, Expression value)
            => Predicate(property, PredicateOperator.GreaterThan, value);

        public FilterBuilder<T> GreaterThanOrEqual(Expression property, Expression value)
            => Predicate(property, PredicateOperator.GreaterThanOrEqual, value);

        public FilterBuilder<T> LessThan(Expression property, Expression value)
            => Predicate(property, PredicateOperator.LessThan, value);

        public FilterBuilder<T> LessThanOrEqual(Expression property, Expression value)
            => Predicate(property, PredicateOperator.LessThanOrEqual, value);

        public FilterBuilder<T> Logical(Expression left, LogicalOperator @operator, Expression right)
        {
            Visit(right);
            Visit(left);
            _filters.Push(new LogicalFilter(_filters.Pop(), @operator, _filters.Pop()));
            return this;
        }

        public FilterBuilder<T> NotEqual(Expression property, Expression value)
            => Predicate(property, PredicateOperator.NotEqual, value);

        public FilterBuilder<T> OrElse(Expression left, Expression right)
            => Logical(left, LogicalOperator.Or, right);

        public FilterBuilder<T> Predicate(Expression left, PredicateOperator @operator, Expression right)
        {
            var property = new FilterPropertyBuilder(Expression);
            property.Visit(left);
            var value = new FilterValueBuilder(property.PropertyInfo, Expression);
            value.Visit(right);
            _filters.Push(new PredicateFilter(property.Property, @operator, value.Value));
            return this;
        }

        public Filter ToFilter() => _filters.Single();

        public override Expression Visit(Expression node)
        {
            if (IsTerminal(node)) return node;

            switch (node.NodeType)
            {
                case ExpressionType.AndAlso:
                case ExpressionType.Call:
                case ExpressionType.Convert:
                case ExpressionType.Equal:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.NotEqual:
                case ExpressionType.OrElse:
                    return base.Visit(node);
                default:
                    throw new InvalidOperationException($"Invalid expression '{node}'.");
            }
        }

        private bool IsTerminal(Expression expression)
            => Expression?.Equals(expression) == true;

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (!_binary.TryGetValue(node.NodeType, out var binary))
                throw new InvalidOperationException($"Invalid binary expression '{node}'");
            binary(node.Left, node.Right);
            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var method = node.Method;
            var info = method.IsGenericMethod
                ? method.GetGenericMethodDefinition()
                : null;
            if (!_call.TryGetValue(info, out var call))
                throw new InvalidOperationException($"Invalid method call expression '{node}'");
            call(node.Arguments[0], node.Arguments[1]);
            return node;
        }
    }
}