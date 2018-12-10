namespace Questar.OneRoster.DataServices.EntityFrameworkCore
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper.EntityFrameworkCore;
    using AutoMapper.Extensions.ExpressionMapping.Impl;
    using Refactor;

    public class SourceInjectedRepository<T> : Repository<T>
        where T : class
    {
        public SourceInjectedRepository(ISourceInjectedQueryable<T> source, IPersistence persistence, Expression<Func<T, object>> keySelector, Expression<Func<object, object, bool>> keyComparer)
        {
            Source = source;
            Persistence = persistence;
            KeySelector = keySelector;
            KeyComparer = keyComparer;
        }

        protected ISourceInjectedQueryable<T> Source { get; }

        protected IPersistence Persistence { get; }

        protected Expression<Func<T, object>> KeySelector { get; }

        protected Expression<Func<object, object, bool>> KeyComparer { get; }

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

        public override IQuery<T> AsQuery() => new Query<T>(Source, KeySelector, KeyComparer);
    }
}