namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.Extensions.ExpressionMapping;
    using DataServices;
    using DataServices.EntityFrameworkCore;
    using Models;
    using Class = Data.Class;

    public class ClassRepository : BaseObjectRepository<Models.Class, Class>, IClassRepository
    {
        public ClassRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public IQuery<LineItem> GetLineItemsForClass(string classId) =>
            Context.LineItems
                .Where(item => item.ClassId == Guid.Parse(classId))
                .UseAsDataSource(Mapper)
                .For<LineItem>()
                .ToBaseQuery();

        public IQuery<Result> GetResultsForLineItemForClass(string classId, string lineItemId) =>
            Context.Results
                .Where(result => result.LineItem.ClassId == Guid.Parse(lineItemId) && result.LineItemId == Guid.Parse(lineItemId))
                .UseAsDataSource(Mapper)
                .For<Result>()
                .ToBaseQuery();

        public IQuery<Resource> GetResourcesForClass(string classId) =>
            Context.Resources
                .Where(resource => resource.Classes.Any(@class => @class.ClassId == Guid.Parse(classId)))
                .UseAsDataSource(Mapper)
                .For<Resource>()
                .ToBaseQuery();

        public IQuery<Result> GetResultsForClass(string classId) =>
            Context.Results
                .Where(result => result.LineItem.ClassId == Guid.Parse(classId))
                .UseAsDataSource(Mapper)
                .For<Result>()
                .ToBaseQuery();

        public IQuery<User> GetStudentsForClass(string classId) =>
            Context.Users
                .Where(user => user.Type == UserType.Student && user.Enrollments.Any(enrollment => enrollment.ClassId == Guid.Parse(classId)))
                .UseAsDataSource(Mapper)
                .For<User>()
                .ToBaseQuery();

        public IQuery<Result> GetResultsForStudentForClass(string classId, string studentId) =>
            Context.Results
                .Where(result => result.LineItem.ClassId == Guid.Parse(classId) && result.StudentId == Guid.Parse(studentId))
                .UseAsDataSource(Mapper)
                .For<Result>()
                .ToBaseQuery();

        public IQuery<User> GetTeachersForClass(string classId) =>
            Context.Users
                .Where(user => user.Type == UserType.Teacher && user.Enrollments.Any(enrollment => enrollment.ClassId == Guid.Parse(classId)))
                .UseAsDataSource(Mapper)
                .For<User>()
                .ToBaseQuery();
    }
}