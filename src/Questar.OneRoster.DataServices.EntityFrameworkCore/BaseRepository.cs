using System.Linq;
using System.Threading.Tasks;
using AutoMapper.EntityFrameworkCore;
using AutoMapper.Extensions.ExpressionMapping.Impl;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.DataServices.EntityFrameworkCore
{
    public class BaseRepository<TModel, TSource> : Repository<TModel>
        where TModel : Base
    {
        public BaseRepository(ISourceInjectedQueryable<TModel> source, IPersistence<TSource> persistence)
        {
            Source = source;
            Persistence = persistence;
        }

        protected ISourceInjectedQueryable<TModel> Source { get; }

        protected IPersistence<TSource> Persistence { get; }

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

        public override IQueryable<TModel> AsQueryable()
        {
            return Source;
        }

        public override IQuery<TModel> AsQuery()
        {
            return new BaseQuery<TModel>(Source);
        }
    }
}