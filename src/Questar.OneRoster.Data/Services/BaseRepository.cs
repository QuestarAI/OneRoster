namespace Questar.OneRoster.Data.Services
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.EntityFrameworkCore;
    using AutoMapper.Extensions.ExpressionMapping;
    using DataServices.EntityFrameworkCore;
    using Models;

    public class BaseRepository<TModel, TSource> : SourceInjectedRepository<TModel, TSource>
        where TModel : Base
        where TSource : class, IBaseObject
    {
        public BaseRepository(OneRosterDbContext context, IMapper mapper)
            : this(context, mapper, context.Set<TSource>())
        {
            Context = context;
            Mapper = mapper;
        }

        public BaseRepository(OneRosterDbContext context, IMapper mapper, IQueryable<TSource> query)
            : base(query.UseAsDataSource(mapper).For<TModel>(), context.Set<TSource>().Persist(mapper), model => model.SourcedId, (x, y) => (string) x == (string) y)
        {
            Context = context;
            Mapper = mapper;
        }

        protected OneRosterDbContext Context { get; }

        protected IMapper Mapper { get; }
    }
}