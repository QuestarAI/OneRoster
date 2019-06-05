using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Questar.OneRoster.Filtering
{
    public sealed class FilterBuilder<T> : ExpressionVisitor
    {
        private readonly Stack<Filter> _filters = new Stack<Filter>();

        public FilterBuilder(Expression expression)
        {
            Expression = expression;
        }

        public Expression Expression { get; }

        public FilterBuilder<T> AndAlso(Expression left, Expression right)
        {
            return Logical(left, LogicalOperator.And, right);
        }

        public FilterBuilder<T> Any(Expression property, Expression value)
        {
            return Predicate(property, PredicateOperator.Contains, value);
        }

        public FilterBuilder<T> All(Expression property, Expression value)
        {
            return Predicate(property, PredicateOperator.Equal, value);
        }

        public FilterBuilder<T> Equal(Expression property, Expression value)
        {
            return Predicate(property, PredicateOperator.Equal, value);
        }

        public FilterBuilder<T> GreaterThan(Expression property, Expression value)
        {
            return Predicate(property, PredicateOperator.GreaterThan, value);
        }

        public FilterBuilder<T> GreaterThanOrEqual(Expression property, Expression value)
        {
            return Predicate(property, PredicateOperator.GreaterThanOrEqual, value);
        }

        public FilterBuilder<T> LessThan(Expression property, Expression value)
        {
            return Predicate(property, PredicateOperator.LessThan, value);
        }

        public FilterBuilder<T> LessThanOrEqual(Expression property, Expression value)
        {
            return Predicate(property, PredicateOperator.LessThanOrEqual, value);
        }

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
        {
            return Predicate(property, PredicateOperator.NotEqual, value);
        }

        public FilterBuilder<T> OrElse(Expression left, Expression right)
        {
            return Logical(left, LogicalOperator.Or, right);
        }

        public FilterBuilder<T> Predicate(Expression left, PredicateOperator @operator, Expression right)
        {
            var property = new FilterPropertyBuilder(Expression);
            property.Visit(left);
            var value = new FilterValueBuilder(property.PropertyInfo, Expression);
            value.Visit(right);
            _filters.Push(new PredicateFilter(property.Property, @operator, value.Value));
            return this;
        }

        public Filter ToFilter()
        {
            return _filters.Single();
        }

        public override Expression Visit(Expression node)
        {
            if (IsTerminal(node))
                return node;
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
        {
            return Expression?.Equals(expression) == true;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            PredicateBuilder(node)(node.Left, node.Right);
            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            ContainsBuilder(node)(node.Arguments[0], node.Arguments[1]);
            return node;
        }

        private Func<Expression, Expression, FilterBuilder<T>> ContainsBuilder(MethodCallExpression node)
        {
            var method = node.Method;
            var info = method.IsGenericMethod
                ? method.GetGenericMethodDefinition()
                : null;
            switch (info)
            {
                case MethodInfo all when all == FilterInfo.All:
                    return All;
                case MethodInfo any when any == FilterInfo.Any:
                    return Any;
                default:
                    throw new NotSupportedException($"Method call expression not supported '{node}'.");
            }
        }

        private Func<Expression, Expression, FilterBuilder<T>> PredicateBuilder(BinaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.AndAlso:
                    return AndAlso;
                case ExpressionType.Equal:
                    return Equal;
                case ExpressionType.GreaterThan:
                    return GreaterThan;
                case ExpressionType.GreaterThanOrEqual:
                    return GreaterThanOrEqual;
                case ExpressionType.LessThan:
                    return LessThan;
                case ExpressionType.LessThanOrEqual:
                    return LessThanOrEqual;
                case ExpressionType.NotEqual:
                    return NotEqual;
                case ExpressionType.OrElse:
                    return OrElse;
                default:
                    throw new NotSupportedException($"Binary expression not supported '{node}'.");
            }
        }
    }
}