namespace Questar.OneRoster.Data.Services
{
    using System;
    using AutoMapper;
    using AutoMapper.EntityFrameworkCore;
    using AutoMapper.Extensions.ExpressionMapping;
    using DataServices;
    using DataServices.EntityFrameworkCore;
    using Models;
    using AcademicSession = Data.AcademicSession;
    using Category = Data.Category;
    using Class = Data.Class;
    using Course = Data.Course;
    using Demographics = Data.Demographics;
    using Enrollment = Data.Enrollment;
    using LineItem = Data.LineItem;
    using Org = Data.Org;
    using Resource = Data.Resource;
    using Result = Data.Result;
    using User = Data.User;

    public class OneRosterDbContextWorkspace : DbContextWorkspace<OneRosterDbContext>
    {
        public OneRosterDbContextWorkspace(OneRosterDbContext context, IMapper mapper) : base(context) => Mapper = mapper;
        public IMapper Mapper { get; }

        protected override void Configure(WorkspaceBuilder builder)
        {
            SourceInjectedRepository<TModel> CreateRepository<TModel, TEntity>()
                where TModel : Base
                where TEntity : class, IBaseObject
            {
                var set = Context.Set<TEntity>();
                var source = set.UseAsDataSource(Mapper).For<TModel>();
                var persistence = set.Persist(Mapper);
                return new SourceInjectedRepository<TModel>(source, persistence, model => model.SourcedId, (x, y) => (Guid) x == (Guid) y);
            }

            builder.Add(CreateRepository<Models.AcademicSession, AcademicSession>());
            builder.Add(CreateRepository<Models.Category, Category>());
            builder.Add(CreateRepository<Models.Class, Class>());
            builder.Add(CreateRepository<Models.Course, Course>());
            builder.Add(CreateRepository<Models.Demographics, Demographics>());
            builder.Add(CreateRepository<Models.Enrollment, Enrollment>());
            builder.Add(CreateRepository<Models.LineItem, LineItem>());
            builder.Add(CreateRepository<Models.Org, Org>());
            builder.Add(CreateRepository<Models.Resource, Resource>());
            builder.Add(CreateRepository<Models.Result, Result>());
            builder.Add(CreateRepository<Models.User, User>());
        }
    }
}