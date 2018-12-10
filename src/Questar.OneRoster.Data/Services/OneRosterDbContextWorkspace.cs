namespace Questar.OneRoster.Data.Services
{
    using System;
    using AutoMapper;
    using AutoMapper.EntityFrameworkCore;
    using AutoMapper.Extensions.ExpressionMapping;
    using DataServices;
    using DataServices.EntityFrameworkCore;
    using Models;

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

            builder.Add(CreateRepository<AcademicSession, Data.AcademicSession>());
            builder.Add(CreateRepository<Category, Data.Category>());
            builder.Add(CreateRepository<Class, Data.Class>());
            builder.Add(CreateRepository<Course, Data.Course>());
            builder.Add(CreateRepository<Demographics, Data.Demographics>());
            builder.Add(CreateRepository<Enrollment, Data.Enrollment>());
            builder.Add(CreateRepository<LineItem, Data.LineItem>());
            builder.Add(CreateRepository<Org, Data.Org>());
            builder.Add(CreateRepository<Resource, Data.Resource>());
            builder.Add(CreateRepository<Result, Data.Result>());
            builder.Add(CreateRepository<User, Data.User>());
        }
    }
}