namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Collections;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query.Internal;
    using OneRoster.Collections;
    using Sorting;

    public class DbSetRepository<T> : IRepository<T>, IAsyncEnumerableAccessor<T> where T : class
    {
        public DbSetRepository(DbSet<T> set) => Set = set;

        protected DbSet<T> Set { get; }

        public IAsyncEnumerable<T> AsyncEnumerable => Set.ToAsyncEnumerable();

        bool IRepository.IsReadOnly => false;

        public int Count() => Set.Count();

        public Task<int> CountAsync() => Set.CountAsync();

        public void Remove(T entity) => Set.Remove(entity);

        public Task<T> Single(SingleQueryParams @params)
            => Set.FindAsync(@params.SourceId);

        public Task<Page<T>> Select(SelectQueryParams @params)
            => Set
                .Where(@params.Filter.ToFilterExpression<T>())
                .SortBy(@params.SortField, @params.SortDirection)
                .ToPageAsync(@params.PageOffset / @params.PageLimit, @params.PageLimit);

        public void Add(T entity) => Set.Add(entity);

        public IEnumerator<T> GetEnumerator() => Set.AsQueryable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Type ElementType => Set.AsQueryable().ElementType;

        public Expression Expression => Set.AsQueryable().Expression;

        public IQueryProvider Provider => Set.AsQueryable().Provider;
    }
}