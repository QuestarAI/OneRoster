namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;

    internal sealed class FilterExpressionVisitor<T> : ExpressionVisitor
    {
        private readonly Stack<FilterStringBuilder<T>> _parts;

        public FilterExpressionVisitor(FilterStringBuilder<T> stringBuilder)
        {
            _parts = new Stack<FilterStringBuilder<T>>(new[] { stringBuilder });
        }

        public FilterStringBuilder<T> Part => _parts.Peek();

        private static object Evaluate(Expression node)
        {
            var convert = Expression.Convert(node, typeof(object));
            var lambda = Expression.Lambda<Func<object>>(convert);
            var getter = lambda.Compile();
            return getter();
        }

        private string ToString(Expression expression)
        {
            _parts.Push(new FilterStringBuilder<T>());
            Visit(expression);
            return _parts.Pop().ToFilterString();
        }

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

        protected override Expression VisitBinary(BinaryExpression node)
        {
            Action<string, string> binary;

            switch (node.NodeType)
            {
                case ExpressionType.AndAlso:
                    binary = Part.AndAlso;
                    break;
                case ExpressionType.Equal:
                    binary = Part.Equal;
                    break;
                case ExpressionType.GreaterThan:
                    binary = Part.GreaterThan;
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    binary = Part.GreaterThanOrEqual;
                    break;
                case ExpressionType.LessThan:
                    binary = Part.LessThan;
                    break;
                case ExpressionType.LessThanOrEqual:
                    binary = Part.LessThanOrEqual;
                    break;
                case ExpressionType.NotEqual:
                    binary = Part.NotEqual;
                    break;
                case ExpressionType.OrElse:
                    binary = Part.OrElse;
                    break;
                default:
                    throw new InvalidOperationException($"Invalid binary expression '{node.NodeType}'");
            }

            binary(ToString(node.Left), ToString(node.Right));

            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Part.Value(node.Value);

            return node;
        }

        protected override Expression VisitLambda<TDelegate>(Expression<TDelegate> node)
        {
            return base.Visit(node.Body) ?? throw new InvalidOperationException($"Couldn't visit lambda body '{node.Body}'.");
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            var instance = node.Expression;
            var name = node.Member.Name;

            switch (instance.NodeType)
            {
                case ExpressionType.MemberAccess:
                    Part.Property($"{ToString(instance)}.{name}");
                    break;
                case ExpressionType.Constant:
                    Part.Value(Evaluate(node));
                    break;
                default:
                    Part.Property(name);
                    break;
            }

            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var method = node.Method;

            Action<string, string> contains;

            switch (method.IsGenericMethod ? method.GetGenericMethodDefinition() : null)
            {
                case MethodInfo all when all == FilterInfo.Any:
                    contains = Part.Any;
                    break;
                case MethodInfo any when any == FilterInfo.All:
                    contains = Part.All;
                    break;
                default:
                    throw new NotSupportedException($"Unsupported method expression '{method}'.");
            }

            contains(ToString(node.Arguments[1]), ToString(node.Arguments[0]));

            return node;
        }
    }
}