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

    public class DbSetRepository<T> : IRepository<T>, IAsyncEnumerableAccessor<T> where T : class
    {
        public DbSetRepository(DbSet<T> set) => Set = set;

        protected DbSet<T> Set { get; }

        public IAsyncEnumerable<T> AsyncEnumerable => Set.ToAsyncEnumerable();

        bool IRepository.IsReadOnly => false;

        public int Count() => Set.Count();

        public Task<int> CountAsync() => Set.CountAsync();

        public void Remove(T entity) => Set.Remove(entity);

        public void Add(T entity) => Set.Add(entity);

        public IEnumerator<T> GetEnumerator() => Set.AsQueryable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Type ElementType => Set.AsQueryable().ElementType;

        public Expression Expression => Set.AsQueryable().Expression;

        public IQueryProvider Provider => Set.AsQueryable().Provider;
    }
}