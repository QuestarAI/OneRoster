namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Linq.Expressions;

    public sealed class FilterPropertyBuilder : ExpressionVisitor
    {
        public FilterPropertyBuilder() : this(null)
        {
        }

        public FilterPropertyBuilder(Expression expression)
            => Expression = expression;

        public Expression Expression { get; }

        public FilterProperty Value { get; private set; }

        public override Expression Visit(Expression node)
        {
            if (IsTerminal(node)) return node;

            switch (node.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.MemberAccess:
                    return base.Visit(node);
                default:
                    throw new InvalidOperationException($"Invalid expression '{node}'.");
            }
        }

        private bool IsTerminal(Expression expression)
            => Expression?.Equals(expression) == true;

        protected override Expression VisitMember(MemberExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Constant:
                    break;
                case ExpressionType.MemberAccess:
                    Visit(node.Expression);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid member expression '{node}'.");
            }

            Value = new FilterProperty(node.Member.Name, Value);
            return node;
        }
    }
}