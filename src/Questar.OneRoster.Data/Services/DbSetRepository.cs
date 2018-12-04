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
    using Models;
    using OneRoster.Collections;
    using Sorting;

    public class DbSetRepository<T> : IRepository<T>, IQueryable, IAsyncEnumerableAccessor<T> where T : Base
    {
        public DbSetRepository(DbSet<T> set) => Set = set;

        protected DbSet<T> Set { get; }

        public IAsyncEnumerable<T> AsyncEnumerable => Set.ToAsyncEnumerable();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Type ElementType => Set.AsQueryable().ElementType;

        public Expression Expression => Set.AsQueryable().Expression;

        public IQueryProvider Provider => Set.AsQueryable().Provider;

        bool IRepository.IsReadOnly => false;

        public int Count() => Set.Count();

        public Task<int> CountAsync() => Set.CountAsync();

        public async Task Delete(T entity) => Set.Remove(entity);

        public virtual Task<T> Single(SingleQueryParams @params)
            => Set.FindAsync(@params.SourceId);

        public virtual Task<Page<T>> Select(SelectQueryParams @params)
            /* TODO EntityMapper.Map(entity)? */
            => Set
                .Where(@params.Filter.ToFilterExpression<T>()) /* TODO EntityMapper.Map(@params.Filter.ToExpression<T>())? */
                .SortBy(@params.SortField, @params.SortDirection) /* TODO EntityMapper.Map(@params.SortField.ToExpression<T>())? */
                .ToPageAsync(@params.PageOffset / @params.PageLimit, @params.PageLimit);

        public virtual async Task Upsert(T entity)
        {
            var result = await Set.FindAsync(entity.SourcedId);
            if (result == null)
                await Set.AddAsync(entity); // TODO EntityMapper.Map(entity)
        }

        public IEnumerator<T> GetEnumerator() => Set.AsQueryable().GetEnumerator();
    }
}