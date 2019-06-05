using System.Linq;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.DataServices.EntityFrameworkCore;

namespace Questar.OneRoster.Data.Services
{
    public class CourseRepository : BaseObjectRepository<Models.Course, Course>, ICourseRepository
    {
        public CourseRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public IQuery<Models.Class> GetClassesForCourse(string courseId)
        {
            return Context.Classes
                .Where(@class => @class.CourseId == int.Parse(courseId))
                .UseAsDataSource(Mapper)
                .For<Models.Class>()
                .ToBaseQuery();
        }

        public IQuery<Models.Resource> GetResourcesForCourse(string courseId)
        {
            return Context.Resources
                .Where(resource => resource.Courses.Any(course => course.CourseId == int.Parse(courseId)))
                .UseAsDataSource(Mapper)
                .For<Models.Resource>()
                .ToBaseQuery();
        }
    }
}