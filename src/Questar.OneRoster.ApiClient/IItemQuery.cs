using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Questar.OneRoster.ApiClient
{
    public interface IItemQuery<TSource, TContext>
    {
        IItemQuery<TSource, TResult> Fields<TResult>(Expression<Func<TContext, TResult>> selector);

        Task<TContext> SingleAsync();
    }

    public interface IItemQuery<TSource> : IItemQuery<TSource, TSource>
    {
    }
}