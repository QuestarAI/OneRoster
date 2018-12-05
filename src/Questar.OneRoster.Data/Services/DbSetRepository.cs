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
    using Models;

    //public class DbSetRepositoryAdapter<TSource, TEntity> : IRepository<TSource>
    //    where TSource : Base
    //    where TEntity : class, IBaseObject
    //{
    //}

    public class DbSetRepository<T> : IRepository<T>, IQueryable, IAsyncEnumerableAccessor<T>
        where T : Base
    {
        public DbSet<T> Set { get; }

        public DbSetRepository(DbSet<T> set) => Set = set;

        public IAsyncEnumerable<T> AsyncEnumerable => Set.ToAsyncEnumerable();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Type ElementType => Set.AsQueryable().ElementType;

        public Expression Expression => Set.AsQueryable().Expression;

        public IQueryProvider Provider => Set.AsQueryable().Provider;

        bool IRepository.IsReadOnly => false;

        public int Count() => Set.Count();

        public Task<int> CountAsync() => Set.CountAsync();

        public async Task Delete(T entity)
        {
            await Task.Yield();
            Set.Remove(entity);
        }

        public ISelectQuery<T> Select() => new SelectQuery<T>(Set);

        public ISingleQuery<T> Single() => new SingleQuery<T>(Set);

        public virtual async Task Upsert(T entity)
        {
            var found = Set.FindAsync(entity.SourcedId);
            if (found == null)
                await Set.AddAsync(entity);
        }

        public virtual IEnumerator<T> GetEnumerator() => Set.AsQueryable().GetEnumerator();
    }
}