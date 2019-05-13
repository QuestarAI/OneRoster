namespace Questar.OneRoster.DataServices.EntityFrameworkCore
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper.EntityFrameworkCore;
    using AutoMapper.Extensions.ExpressionMapping.Impl;

    public class SourceInjectedRepository<TModel, TSource> : Repository<TModel>
        where TModel : class
    {
        public SourceInjectedRepository(ISourceInjectedQueryable<TModel> source, IPersistence<TSource> persistence, Expression<Func<TModel, object>> keySelector, Expression<Func<object, object, bool>> keyComparer)
        {
            Source = source;
            Persistence = persistence;
            KeySelector = keySelector;
            KeyComparer = keyComparer;
        }

        protected ISourceInjectedQueryable<TModel> Source { get; }

        protected IPersistence<TSource> Persistence { get; }

        protected Expression<Func<TModel, object>> KeySelector { get; }

        protected Expression<Func<object, object, bool>> KeyComparer { get; }

        public override Task UpsertAsync(TModel entity)
        {
            Persistence.InsertOrUpdate(entity);
            return Task.CompletedTask;
        }

        public override Task DeleteAsync(TModel entity)
        {
            Persistence.Remove(entity);
            return Task.CompletedTask;
        }

        public override IQueryable<TModel> AsQueryable() => Source;

        public override IQuery<TModel> AsQuery() => new SourceInjectedQuery<TModel>(Source, KeySelector, KeyComparer);
    }
}