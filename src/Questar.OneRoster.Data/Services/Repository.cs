namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query.Internal;

    public abstract class Repository<T> : IRepository<T>, IQueryable, IAsyncEnumerableAccessor<T>
    {
        public IAsyncEnumerable<T> AsyncEnumerable => AsQueryable().ToAsyncEnumerable();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Type ElementType => AsQueryable().ElementType;

        public Expression Expression => AsQueryable().Expression;

        public IQueryProvider Provider => AsQueryable().Provider;

        Type IRepository.Type => typeof(T);

        bool IRepository.IsReadOnly => false;

        public int Count() => AsQueryable().Count();

        public Task<int> CountAsync() => AsQueryable().CountAsync();

        public abstract Task DeleteAsync(T entity);

        public abstract IQuery<T> AsQuery();

        IQuery IRepository.AsQuery() => AsQuery();

        public abstract Task UpsertAsync(T entity);

        public abstract IQueryable<T> AsQueryable();

        public virtual IEnumerator<T> GetEnumerator() => AsQueryable().GetEnumerator();
    }
}