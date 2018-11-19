namespace Questar.OneRoster.Filtering.Expressions
{
    using System;
    using System.Linq.Expressions;

    public class FilterValueExpressionVisitor<T> : ExpressionVisitor
    {
        public FilterValueExpressionVisitor(FilterValueBuilder builder, FilterFactory factory)
        {
            Builder = builder;
            Factory = factory;
        }

        public FilterValueBuilder Builder { get; }

        public FilterFactory Factory { get; }

        public override Expression Visit(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Constant:
                case ExpressionType.NewArrayInit:
                    return base.Visit(node);
                default:
                    throw new InvalidOperationException($"Invalid expression node type '{node.NodeType}'.");
            }
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Builder.Constant(node);
            return node;
        }

        // is this used?
        protected override Expression VisitNewArray(NewArrayExpression node)
        {
            Builder.NewArray(node);
            return node;
        }
    }
}