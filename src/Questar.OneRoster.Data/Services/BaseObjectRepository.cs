namespace Questar.OneRoster.Data.Services
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.EntityFrameworkCore;
    using AutoMapper.Extensions.ExpressionMapping;
    using DataServices.EntityFrameworkCore;
    using Models;

    public class BaseObjectRepository<TModel, TSource> : BaseRepository<TModel, TSource>
        where TModel : Base
        where TSource : class, IBaseObject
    {
        public BaseObjectRepository(OneRosterDbContext context, IMapper mapper)
            : this(context, mapper, context.Set<TSource>())
        {
            Context = context;
            Mapper = mapper;
        }

        public BaseObjectRepository(OneRosterDbContext context, IMapper mapper, IQueryable<TSource> query)
            : base(query.UseAsDataSource(mapper).For<TModel>(), context.Set<TSource>().Persist(mapper))
        {
            Context = context;
            Mapper = mapper;
        }

        protected OneRosterDbContext Context { get; }

        protected IMapper Mapper { get; }
    }
}