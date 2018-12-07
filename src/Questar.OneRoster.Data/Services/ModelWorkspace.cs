namespace Questar.OneRoster.Data.Services
{
    using System;
    using AutoMapper;
    using AutoMapper.EntityFrameworkCore;
    using AutoMapper.Extensions.ExpressionMapping;
    using Models;
    using AcademicSession = Data.AcademicSession;
    using Category = Data.Category;
    using Class = Data.Class;
    using Course = Data.Course;
    using Demographics = Data.Demographics;
    using Enrollment = Data.Enrollment;
    using LineItem = Data.LineItem;
    using Resource = Data.Resource;
    using Result = Data.Result;
    using User = Data.User;

    public class ModelWorkspace : DbContextWorkspace<OneRosterDbContext>
    {
        public ModelWorkspace(OneRosterDbContext context, IMapper mapper) : base(context) => Mapper = mapper;
        public IMapper Mapper { get; }

        protected override void Configure(WorkspaceBuilder builder)
        {
            ModelRepository<TModel> ModelRepository<TModel, TEntity>()
                where TModel : Base
                where TEntity : class, IBaseObject
            {
                var set = Context.Set<TEntity>();
                var source = set.UseAsDataSource(Mapper).For<TModel>();
                var persistence = set.Persist(Mapper);
                return new ModelRepository<TModel>(source, persistence, model => model.SourcedId, (x, y) => (Guid) x == (Guid) y);
            }

            builder.Add(ModelRepository<Models.AcademicSession, AcademicSession>());
            builder.Add(ModelRepository<Models.Category, Category>());
            builder.Add(ModelRepository<Models.Class, Class>());
            builder.Add(ModelRepository<Models.Course, Course>());
            builder.Add(ModelRepository<Models.Demographics, Demographics>());
            builder.Add(ModelRepository<Models.Enrollment, Enrollment>());
            builder.Add(ModelRepository<Models.LineItem, LineItem>());
            builder.Add(ModelRepository<Models.Resource, Resource>());
            builder.Add(ModelRepository<Models.Result, Result>());
            builder.Add(ModelRepository<Models.User, User>());
        }
    }
}