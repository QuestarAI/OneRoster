namespace Questar.OneRoster.DataServices.EntityFrameworkCore
{
    using AutoMapper.EntityFrameworkCore;
    using AutoMapper.Extensions.ExpressionMapping.Impl;
    using Models;

    public class BaseRepository<TModel, TSource> : SourceInjectedRepository<TModel, TSource>
        where TModel : Base
    {
        public BaseRepository(ISourceInjectedQueryable<TModel> source, IPersistence<TSource> persistence)
            : base(source, persistence, @base => @base.SourcedId, (x, y) => (string) x == (string) y)
        {
        }
    }
}