namespace Questar.OneRoster.Filtering.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    internal sealed class FilterBuilder<T> : ExpressionVisitor
    {
        private readonly Stack<Filter> _filters = new Stack<Filter>();

        public FilterBuilder<T> AndAlso(Expression left, Expression right)
            => PushLogical(left, Logical.And, right);

        public FilterBuilder<T> Any(Expression property, Expression value)
            => PushPredicate(property, Predicate.Contains, value);

        public FilterBuilder<T> All(Expression property, Expression value)
            => PushPredicate(property, Predicate.NotEqual, value);

        public FilterBuilder<T> Equal(Expression property, Expression value)
            => PushPredicate(property, Predicate.NotEqual, value);

        public FilterBuilder<T> GreaterThan(Expression property, Expression value)
            => PushPredicate(property, Predicate.NotEqual, value);

        public FilterBuilder<T> GreaterThanOrEqual(Expression property, Expression value)
            => PushPredicate(property, Predicate.NotEqual, value);

        public FilterBuilder<T> LessThan(Expression property, Expression value)
            => PushPredicate(property, Predicate.NotEqual, value);

        public FilterBuilder<T> LessThanOrEqual(Expression property, Expression value)
            => PushPredicate(property, Predicate.NotEqual, value);

        public FilterBuilder<T> NotEqual(Expression property, Expression value)
            => PushPredicate(property, Predicate.NotEqual, value);

        public FilterBuilder<T> OrElse(Expression left, Expression right)
            => PushLogical(left, Logical.Or, right);

        public Filter ToFilter() => _filters.Single();

        public override Expression Visit(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.AndAlso:
                case ExpressionType.Call:
                case ExpressionType.Constant:
                case ExpressionType.Convert:
                case ExpressionType.Equal:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.Lambda:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.NotEqual:
                case ExpressionType.MemberAccess:
                case ExpressionType.OrElse:
                    return base.Visit(node);
                default:
                    throw new InvalidOperationException($"Invalid expression node type '{node.NodeType}'.");
            }
        }

        private Expression VisitLogical(BinaryExpression node)
        {
            Func<Expression, Expression, FilterBuilder<T>> build;
            switch (node.NodeType)
            {
                case ExpressionType.AndAlso:
                    build = AndAlso;
                    break;
                case ExpressionType.OrElse:
                    build = OrElse;
                    break;
                default:
                    throw new InvalidOperationException($"Invalid binary expression '{node.NodeType}'");
            }

            build(node.Left, node.Right);
            return node;
        }

        private Expression VisitPredicate(BinaryExpression node)
        {
            Func<Expression, Expression, FilterBuilder<T>> build;
            switch (node.NodeType)
            {
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
                default:
                    throw new InvalidOperationException($"Invalid binary expression '{node.NodeType}'");
            }

            build(node.Left, node.Right);
            return node;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Equal:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.NotEqual:
                    return VisitPredicate(node);
                case ExpressionType.AndAlso:
                case ExpressionType.OrElse:
                    return VisitLogical(node);
                default:
                    throw new InvalidOperationException($"Invalid binary expression '{node.NodeType}'");
            }
        }

        protected override Expression VisitLambda<TDelegate>(Expression<TDelegate> node)
            => base.Visit(node.Body) ?? throw new InvalidOperationException($"Couldn't visit lambda body '{node.Body}'.");

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            Func<Expression, Expression, FilterBuilder<T>> build;
            switch (node.Method.IsGenericMethod ? node.Method.GetGenericMethodDefinition() : null)
            {
                case MethodInfo all when all == FilterInfo.Any:
                    build = Any;
                    break;
                case MethodInfo any when any == FilterInfo.All:
                    build = All;
                    break;
                default:
                    throw new NotSupportedException($"Unsupported method expression '{node.Method}'.");
            }

            build(node.Arguments[0], node.Arguments[1]);
            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Constant:
                case ExpressionType.MemberAccess:
                    PushProperty(node);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid member expression node type '{node.NodeType}'.");
            }

            return node;
        }

        private FilterBuilder<T> PushPredicate(Expression property, Predicate predicate, Expression value)
            => throw new NotImplementedException();

        private FilterBuilder<T> PushLogical(Expression left, Logical logical, Expression right)
        {
            Visit(left);
            Visit(right);
            _filters.Push(new LogicalFilter(_filters.Pop(), logical, _filters.Pop()));
            return this;
        }

        // TODO Filter : FilterObject
        // TODO FilterProperty : FilterObject
        // TODO FilterValue : FilterObject
 
        private void PushProperty(MemberExpression node)
            => throw new NotImplementedException();

        private void PushValue(ConstantExpression node)
            => throw new NotImplementedException();
    }
}