namespace Questar.OneRoster.Filtering.Expressions
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    internal sealed class FilterExpressionVisitor<T> : ExpressionVisitor
    {
        public FilterExpressionVisitor(FilterBuilder builder, FilterFactory factory)
        {
            Builder = builder;
            Factory = factory;
        }

        public FilterBuilder Builder { get; }

        public FilterFactory Factory { get; }

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
            Func<Expression, Expression, FilterBuilder> build;

            switch (node.NodeType)
            {
                case ExpressionType.AndAlso:
                    build = Builder.AndAlso;
                    break;
                case ExpressionType.OrElse:
                    build = Builder.OrElse;
                    break;
                default:
                    throw new InvalidOperationException($"Invalid binary expression '{node.NodeType}'");
            }

            build(node.Left, node.Right);

            return node;
        }

        private Expression VisitPredicate(BinaryExpression node)
        {
            Func<Expression, Expression, FilterBuilder> build;

            switch (node.NodeType)
            {
                case ExpressionType.Equal:
                    build = Builder.Equal;
                    break;
                case ExpressionType.GreaterThan:
                    build = Builder.GreaterThan;
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    build = Builder.GreaterThanOrEqual;
                    break;
                case ExpressionType.LessThan:
                    build = Builder.LessThan;
                    break;
                case ExpressionType.LessThanOrEqual:
                    build = Builder.LessThanOrEqual;
                    break;
                case ExpressionType.NotEqual:
                    build = Builder.NotEqual;
                    break;
                default:
                    throw new InvalidOperationException($"Invalid binary expression '{node.NodeType}'");
            }

            build(build(node.Left).Pop(), build(node.Right).Pop());

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
            var method = node.Method;

            Action<FilterProperty, FilterValue> build;

            switch (method.IsGenericMethod ? method.GetGenericMethodDefinition() : null)
            {
                case MethodInfo all when all == FilterInfo.Any:
                    build = Builder.Any;
                    break;
                case MethodInfo any when any == FilterInfo.All:
                    build = Builder.All;
                    break;
                default:
                    throw new NotSupportedException($"Unsupported method expression '{method}'.");
            }

            build(Factory.CreateProperty<T>(node.Arguments[0]), Factory.CreateValue<T>(node.Arguments[1]));

            return node;
        }
    }
}