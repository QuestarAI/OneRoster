namespace Questar.OneRoster.Filtering.Expressions
{
    using System;
    using System.Linq.Expressions;

    public class FilterPropertyExpressionVisitor<T> : ExpressionVisitor
    {
        public FilterPropertyExpressionVisitor(FilterPropertyBuilder builder, FilterFactory factory)
        {
            Builder = builder;
            Factory = factory;
        }

        //var instance = node.Expression;
        //var name = node.Member.Name;

        //switch (instance.NodeType)
        //{
        //    case ExpressionType.MemberAccess:
        //        Part.Property($"{ToString(instance)}.{name}");
        //        break;
        //    case ExpressionType.Constant:
        //        Part.Value(Evaluate(node));
        //        break;
        //    default:
        //        Part.Property(name);
        //        break;
        //}

        public FilterPropertyBuilder Builder { get; }

        public FilterFactory Factory { get; }

        public override Expression Visit(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return base.Visit(node);
                default:
                    throw new InvalidOperationException($"Invalid expression node type '{node.NodeType}'.");
            }
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Constant:
                    Builder.Add(node.Member.Name);
                    break;
                case ExpressionType.MemberAccess:
                    Builder.Add($"{Factory.CreateProperty<T>(node.Expression)}.{node.Member.Name}");
                    break;
                default:
                    throw new InvalidOperationException($"Invalid member expression node type '{node.NodeType}'.");
            }

            return node;
        }
    }
}