namespace Questar.OneRoster.Filtering.Expressions
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public sealed class FilterExpression<T> : Expression
    {
        public FilterExpression(Expression<Func<T, bool>> expression)
            => Expression = expression;

        public Expression<Func<T, bool>> Expression { get; }

        public override bool CanReduce
            => Expression.CanReduce;

        public override ExpressionType NodeType
            => Expression.NodeType;

        public override Type Type
            => Expression.Type;

        protected override Expression Accept(ExpressionVisitor visitor)
            => visitor.Visit(Expression);

        public override Expression Reduce()
            => Expression.Reduce();

        public override string ToString()
            => Expression.ToString();

        protected override Expression VisitChildren(ExpressionVisitor visitor)
        {
            visitor.Visit(Expression.Body);
            visitor.Visit(Expression.Parameters.Single());
            return Expression;
        }

        public override bool Equals(object obj)
            => Expression.Equals(obj);

        public override int GetHashCode()
            => Expression.GetHashCode();

        public Func<T, bool> Compile()
            => Expression.Compile();

        public static implicit operator Expression<Func<T, bool>>(FilterExpression<T> filter)
            => filter.Expression;

        public static implicit operator FilterExpression<T>(Expression<Func<T, bool>> value)
            => new FilterExpression<T>(value);

        public Filter ToFilter()
        {
            var builder = new FilterBuilder<T>();
            builder.Visit(Expression.Body);
            return builder.ToFilter();
        }
    }
}