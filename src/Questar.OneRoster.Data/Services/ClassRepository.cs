using System.Linq;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.DataServices.EntityFrameworkCore;

namespace Questar.OneRoster.Data.Services
{
    public class ClassRepository : BaseObjectRepository<Models.Class, Class>, IClassRepository
    {
        public ClassRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public IQuery<Models.LineItem> GetLineItemsForClass(string classId)
        {
            return Context.LineItems
                .Where(item => item.ClassId == classId)
                .UseAsDataSource(Mapper)
                .For<Models.LineItem>()
                .ToBaseQuery();
        }

        public IQuery<Models.Result> GetResultsForLineItemForClass(string classId, string lineItemId)
        {
            return Context.Results
                .Where(result => result.LineItem.ClassId == lineItemId && result.LineItemId == lineItemId)
                .UseAsDataSource(Mapper)
                .For<Models.Result>()
                .ToBaseQuery();
        }

        public IQuery<Models.Resource> GetResourcesForClass(string classId)
        {
            return Context.Resources
                .Where(resource => resource.Classes.Any(@class => @class.ClassId == classId))
                .UseAsDataSource(Mapper)
                .For<Models.Resource>()
                .ToBaseQuery();
        }

        public IQuery<Models.Result> GetResultsForClass(string classId)
        {
            return Context.Results
                .Where(result => result.LineItem.ClassId == classId)
                .UseAsDataSource(Mapper)
                .For<Models.Result>()
                .ToBaseQuery();
        }

        public IQuery<Models.User> GetStudentsForClass(string classId)
        {
            return Context.Users
                .Where(user => user.Type == UserType.Student && user.Enrollments.Any(enrollment => enrollment.ClassId == classId))
                .UseAsDataSource(Mapper)
                .For<Models.User>()
                .ToBaseQuery();
        }

        public IQuery<Models.Result> GetResultsForStudentForClass(string classId, string studentId)
        {
            return Context.Results
                .Where(result => result.LineItem.ClassId == classId && result.StudentId == studentId)
                .UseAsDataSource(Mapper)
                .For<Models.Result>()
                .ToBaseQuery();
        }

        public IQuery<Models.User> GetTeachersForClass(string classId)
        {
            return Context.Users
                .Where(user => user.Type == UserType.Teacher && user.Enrollments.Any(enrollment => enrollment.ClassId == classId))
                .UseAsDataSource(Mapper)
                .For<Models.User>()
                .ToBaseQuery();
        }
    }
}