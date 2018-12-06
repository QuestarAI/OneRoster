using System;

namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using AutoMapper.EntityFrameworkCore;
    using AutoMapper.Extensions.ExpressionMapping;
    using Models;

    public class ModelWorkspace : DbContextWorkspace<OneRosterDbContext>
    {
        public IMapper Mapper { get; }

        public ModelWorkspace(OneRosterDbContext context, IMapper mapper) : base(context) => Mapper = mapper;

        protected override void Configure(WorkspaceBuilder builder)
        {
            ModelRepository<TModel, Guid> ModelRepository<TModel, TEntity>()
                where TModel : Base
                where TEntity : class, IBaseObject
            {
                var set = Context.Set<TEntity>();
                var source = set.UseAsDataSource(Mapper).For<TModel>();
                var persistence = set.Persist(Mapper);
                return new ModelRepository<TModel, Guid>(source, persistence, model => model.SourcedId, (x, y) => x == y);
            }

            builder.Add(ModelRepository<AcademicSession, Data.AcademicSession>());
            builder.Add(ModelRepository<Category, Data.Category>());
            builder.Add(ModelRepository<Class, Data.Class>());
            builder.Add(ModelRepository<Course, Data.Course>());
            builder.Add(ModelRepository<Demographics, Data.Demographics>());
            builder.Add(ModelRepository<Enrollment, Data.Enrollment>());
            builder.Add(ModelRepository<LineItem, Data.LineItem>());
            builder.Add(ModelRepository<Resource, Data.Resource>());
            builder.Add(ModelRepository<Result, Data.Result>());
            builder.Add(ModelRepository<User, Data.User>());
        }
    }
}
