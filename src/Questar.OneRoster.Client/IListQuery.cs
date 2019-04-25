namespace Questar.OneRoster.Client
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Collections;

    public interface IListQuery<TSource, TContext>
    {
        IListQuery<TSource, TResult> Fields<TResult>(Expression<Func<TContext, TResult>> selector);

        IListQuery<TSource, TContext> Filter(Expression<Func<TSource, bool>> predicate);

        IListQuery<TSource, TContext> Limit(int limit);

        IListQuery<TSource, TContext> Offset(int offset);

        IListQuery<TSource, TContext> OrderBy<TResult>(Expression<Func<TSource, TResult>> selector);

        IListQuery<TSource, TContext> OrderByDesc<TResult>(Expression<Func<TSource, TResult>> selector);

        Task<IPage<TContext>> ToPageAsync();
    }

    public interface IListQuery<TSource> : IListQuery<TSource, TSource>
    {
    }
}