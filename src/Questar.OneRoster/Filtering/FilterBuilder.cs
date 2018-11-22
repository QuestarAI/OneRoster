namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public sealed class FilterBuilder<T> : ExpressionVisitor
    {
        private readonly Stack<Filter> _filters = new Stack<Filter>();

        public FilterBuilder(Expression expression)
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
            Visit(left);
            var leftExpression = _filters.Pop();
            Visit(right);
            var rightExpression = _filters.Pop();
            _filters.Push(new LogicalFilter(leftExpression, @operator, rightExpression));
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
                    throw new NotSupportedException($"Expression not supported '{node}'.");
            }
        }

        private bool IsTerminal(Expression expression)
            => Expression?.Equals(expression) == true;

        protected override Expression VisitBinary(BinaryExpression node)
        {
            Func<Expression, Expression, FilterBuilder<T>> build;
            switch (node.NodeType)
            {
                case ExpressionType.AndAlso:
                    build = AndAlso;
                    break;
                case ExpressionType.Equal:
                    build = Equal;
                    break;
                case ExpressionType.GreaterThan:
                    build = GreaterThan;
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    build = GreaterThanOrEqual;
                    break;
                case ExpressionType.LessThan:
                    build = LessThan;
                    break;
                case ExpressionType.LessThanOrEqual:
                    build = LessThanOrEqual;
                    break;
                case ExpressionType.NotEqual:
                    build = NotEqual;
                    break;
                case ExpressionType.OrElse:
                    build = OrElse;
                    break;
                default:
                    throw new NotSupportedException($"Binary expression not supported '{node}'.");
            }
            build(node.Left, node.Right);
            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var method = node.Method;
            var info = method.IsGenericMethod
                ? method.GetGenericMethodDefinition()
                : null;
            Func<Expression, Expression, FilterBuilder<T>> build;
            switch (info)
            {
                case MethodInfo all when all == FilterInfo.All:
                    build = All;
                    break;
                case MethodInfo all when all == FilterInfo.All:
                    build = All;
                    break;
                default:
                    throw new NotSupportedException($"Method call expression not supported '{node}'.");
            }
            build(node.Arguments[0], node.Arguments[1]);
            return node;
        }
    }
}