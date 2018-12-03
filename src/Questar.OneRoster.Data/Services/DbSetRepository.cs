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
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Query.Internal;
    using Microsoft.Extensions.DependencyInjection;
    using Models;
    using OneRoster.Collections;
    using Sorting;

    public class DbSetRepository<T> : IRepository<T>, IQueryable, IAsyncEnumerableAccessor<T> where T : class
    {
        public DbSetRepository(DbSet<T> set) => Set = set;

        protected DbSet<T> Set { get; }

        public IAsyncEnumerable<T> AsyncEnumerable => Set.ToAsyncEnumerable();

        bool IRepository.IsReadOnly => false;

        public int Count() => Set.Count();

        public Task<int> CountAsync() => Set.CountAsync();

        public async Task Delete(T entity) => Set.Remove(entity);

        public virtual Task<T> Single(SingleQueryParams @params)
            => Set.FindAsync(@params.SourceId);

        public virtual Task<Page<T>> Select(SelectQueryParams @params)
            => Set
                .Where(@params.Filter.ToFilterExpression<T>())
                .SortBy(@params.SortField, @params.SortDirection)
                .ToPageAsync(@params.PageOffset / @params.PageLimit, @params.PageLimit);

        public virtual async Task Upsert(T entity)
        {
            var result = await Set.FindAsync(/* TODO entity.SourceId */ -1);
            if (result == null)
                await Set.AddAsync(entity);
        }

        public IEnumerator<T> GetEnumerator() => Set.AsQueryable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Type ElementType => Set.AsQueryable().ElementType;

        public Expression Expression => Set.AsQueryable().Expression;

        public IQueryProvider Provider => Set.AsQueryable().Provider;
    }
}