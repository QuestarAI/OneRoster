namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public sealed class FilterExpression<T> : Expression
    {
        public FilterExpression(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public Expression<Func<T, bool>> Expression { get; }

        public override bool CanReduce => Expression.CanReduce;

        public override ExpressionType NodeType => Expression.NodeType;

        public override Type Type => Expression.Type;

        protected override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.Visit(Expression);
        }

        public override Expression Reduce()
        {
            return Expression.Reduce();
        }

        public override string ToString()
        {
            return Expression.ToString();
        }

        protected override Expression VisitChildren(ExpressionVisitor visitor)
        {
            visitor.Visit(Expression.Body);
            visitor.Visit(Expression.Parameters.Single());
            return Expression;
        }

        public override bool Equals(object obj)
        {
            return Expression.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Expression.GetHashCode();
        }

        public Func<T, bool> Compile()
        {
            return Expression.Compile();
        }

        public static implicit operator Expression<Func<T, bool>>(FilterExpression<T> filter)
        {
            return filter.Expression;
        }

        public static implicit operator FilterExpression<T>(Expression<Func<T, bool>> value)
        {
            return new FilterExpression<T>(value);
        }

        public FilterString<T> ToFilterString()
        {
            var builder = new FilterStringBuilder<T>();
            var visitor = new FilterExpressionVisitor<T>(builder);
            visitor.Visit(this);
            return builder.ToFilterString();
        }
    }
}