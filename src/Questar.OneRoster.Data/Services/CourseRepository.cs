namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.Extensions.ExpressionMapping;
    using DataServices;
    using DataServices.EntityFrameworkCore;
    using Models;
    using Course = Data.Course;

    public class CourseRepository : BaseObjectRepository<Models.Course, Course>, ICourseRepository
    {
        public CourseRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public IQuery<Class> GetClassesForCourse(string courseId) =>
            Context.Classes
                .Where(@class => @class.CourseId == Guid.Parse(courseId))
                .UseAsDataSource(Mapper)
                .For<Class>()
                .ToBaseQuery();

        public IQuery<Resource> GetResourcesForCourse(string courseId) =>
            Context.Resources
                .Where(resource => resource.Courses.Any(course => course.CourseId == Guid.Parse(courseId)))
                .UseAsDataSource(Mapper)
                .For<Resource>()
                .ToBaseQuery();
    }
}