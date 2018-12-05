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
            ModelRepository<TModel, Guid> GetRepository<TModel, TEntity>()
                where TModel : Base
                where TEntity : class, IBaseObject
            {
                var set = Context.Set<TEntity>();
                var source = set.UseAsDataSource().For<TModel>(Mapper);
                var persistence = set.Persist(Mapper);
                return new ModelRepository<TModel, Guid>(source, persistence, model => model.SourcedId, (x, y) => x == y);
            }

            builder.Add(GetRepository<AcademicSession, Data.AcademicSession>());
            builder.Add(GetRepository<Category, Data.Category>());
            builder.Add(GetRepository<Class, Data.Class>());
            builder.Add(GetRepository<Course, Data.Course>());
            builder.Add(GetRepository<Demographics, Data.Demographics>());
            builder.Add(GetRepository<Enrollment, Data.Enrollment>());
            builder.Add(GetRepository<LineItem, Data.LineItem>());
            builder.Add(GetRepository<Resource, Data.Resource>());
            builder.Add(GetRepository<Result, Data.Result>());
            builder.Add(GetRepository<User, Data.User>());
        }
    }
}
