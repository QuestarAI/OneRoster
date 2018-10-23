namespace Questar.OneRoster.Query
{
    using System;
    using System.Linq.Expressions;

    public static class ExpressionExtensions
    {
        /// Logically combines the two expressions with an && operation.
        /// If either expression is <see langword="null" />, returns the other.
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            if (left == null) return right;
            if (right == null) return left;
            var parameter = left.Parameters[0];
            if (ReferenceEquals(parameter, right.Parameters[1]))
            {
                return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left.Body, right.Body), parameter);
            }
            // else fix up the parameters to be identical instances
            var body = Expression.AndAlso(left, right.WithReplacedParameter(parameter));
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        private static Expression WithReplacedParameter<T>(this Expression<Func<T, bool>> expr, ParameterExpression parameter)
            => new ReplaceExpressionVisitor(expr.Body, parameter).Visit(expr.Body);
        
        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression Visit(Expression node)
                => node == _oldValue ? _newValue : base.Visit(node);
        }
    }
}