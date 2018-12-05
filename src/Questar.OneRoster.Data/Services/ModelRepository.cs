namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.EntityFrameworkCore;
    using AutoMapper.Extensions.ExpressionMapping.Impl;

    public class ModelRepository<T, TKey> : Repository<T>
        where T : class
    {
        public ModelRepository(ISourceInjectedQueryable<T> source, IPersistence persistence, Func<T, TKey> keySelector, Func<TKey, TKey, bool> keyComparer)
        {
            Source = source;
            Persistence = persistence;
            KeySelector = keySelector;
            KeyComparer = keyComparer;
        }

        protected ISourceInjectedQueryable<T> Source { get; }

        protected IPersistence Persistence { get; }

        protected Func<T, TKey> KeySelector { get; }

        protected Func<TKey, TKey, bool> KeyComparer { get; }

        public override Task UpsertAsync(T entity)
        {
            Persistence.InsertOrUpdate(entity);
            return Task.CompletedTask;
        }

        public override Task DeleteAsync(T entity)
        {
            Persistence.Remove(entity);
            return Task.CompletedTask;
        }

        public override IQueryable<T> AsQueryable() => Source;

        public override IQuery<T> AsQuery() => new Query<T>(Source, entity => KeySelector(entity), (x, y) => KeyComparer((TKey) x, (TKey) y));
    }
}