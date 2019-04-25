using System;

namespace Questar.OneRoster.Client
{
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Collections;

    public interface INodeEndpoint<T> : INodeQuery<T>
    {
    }

    public interface IListEndpoint<T> : IPageQuery<T>
    {
    }

    public interface IEditEndpoint<T> : INodeEndpoint<T>
    {
        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync();
    }

    public interface INodeQuery<TSource, TContext>
    {
        INodeQuery<TSource, TResult> Fields<TResult>(Expression<Func<TContext, TResult>> selector);

        //INodeQuery<TSource, TResult> Fields<TIntermediate, TResult>(Expression<Func<TSource, TIntermediate>> selector, Func<TContext, TIntermediate, TResult> combiner);

        Task<TContext> SingleAsync();
    }

    public interface INodeQuery<TSource> : INodeQuery<TSource, TSource>
    {
    }

    public interface IPageQuery<TSource, TContext>
    {
        IPageQuery<TSource, TResult> Fields<TResult>(Expression<Func<TContext, TResult>> selector);

        //IPageQuery<TSource, TResult> Fields<TIntermediate, TResult>(Expression<Func<TSource, TIntermediate>> selector, Func<TContext, TIntermediate, TResult> combiner);

        IPageQuery<TSource, TContext> Filter(Expression<Func<TSource, bool>> predicate);

        IPageQuery<TSource, TContext> Limit(int limit);

        IPageQuery<TSource, TContext> Offset(int offset);

        IPageQuery<TSource, TContext> OrderBy<TResult>(Expression<Func<TSource, TResult>> selector);

        IPageQuery<TSource, TContext> OrderByDesc<TResult>(Expression<Func<TSource, TResult>> selector);

        Task<IPage<TContext>> ToPageAsync();
    }

    public interface IPageQuery<TSource> : IPageQuery<TSource, TSource>
    {
    }
}
