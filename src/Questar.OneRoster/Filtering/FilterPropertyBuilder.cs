namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    public sealed class FilterPropertyBuilder : ExpressionVisitor
    {
        public FilterPropertyBuilder(Expression expression)
            => Expression = expression;

        public Expression Expression { get; }

        public PropertyInfo PropertyInfo { get; private set; }

        public FilterProperty Property { get; private set; }

        public override Expression Visit(Expression node)
        {
            if (IsTerminal(node))
                return node;
            switch (node.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.MemberAccess:
                    return base.Visit(node);
                default:
                    throw new NotSupportedException($"Expression '{node}'.not supported.");
            }
        }

        private bool IsTerminal(Expression expression)
            => Expression?.Equals(expression) == true;

        protected override Expression VisitMember(MemberExpression node)
        {
            var property = node.Member as PropertyInfo;
            if (property == null)
                throw new NotSupportedException("Filter property expression must be contain only property member expressions.");
            switch (node.NodeType)
            {
                case ExpressionType.Constant:
                    break;
                case ExpressionType.MemberAccess:
                    Visit(node.Expression);
                    break;
                default:
                    throw new NotSupportedException($"Member expression '{node}' not supported.");
            }
            Property = new FilterProperty(property.Name, Property);
            PropertyInfo = property;
            return node;
        }
    }
}