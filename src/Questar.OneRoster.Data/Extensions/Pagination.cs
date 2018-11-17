namespace Questar.OneRoster.Data.Extensions
{
    using System;
    using System.Linq.Expressions;
    using Remotion.Linq.Parsing.ExpressionVisitors;

    public static class Pagination
    {
        public static Expression<Func<TSource, TTarget>> AndThen<TSource, TIntermediate, TTarget>(this Expression<Func<TSource, TIntermediate>> source, Expression<Func<TIntermediate, TTarget>> target)
        {
            var parameter = source.Parameters[0];
            var body = ReplacingExpressionVisitor.Replace(target.Parameters[0], source.Body, target.Body);
            return Expression.Lambda<Func<TSource, TTarget>>(body, parameter);
        }

        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> source, Expression<Func<T, bool>> target)
        {
            var parameter = Expression.Parameter(typeof(T));
            var left = ReplacingExpressionVisitor.Replace(source.Parameters[0], parameter, source.Body);
            var right = ReplacingExpressionVisitor.Replace(target.Parameters[0], parameter, target.Body);
            var body = Expression.AndAlso(left, right);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        public static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> source, Expression<Func<T, bool>> target)
        {
            var parameter = Expression.Parameter(typeof(T));
            var left = ReplacingExpressionVisitor.Replace(source.Parameters[0], parameter, source.Body);
            var right = ReplacingExpressionVisitor.Replace(target.Parameters[0], parameter, target.Body);
            var body = Expression.OrElse(left, right);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}