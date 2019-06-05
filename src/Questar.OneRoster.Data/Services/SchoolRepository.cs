using System.Linq;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.DataServices.EntityFrameworkCore;

namespace Questar.OneRoster.Data.Services
{
    public class SchoolRepository : BaseObjectRepository<Models.Org, Org>, ISchoolRepository
    {
        public SchoolRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper, context.Set<Org>().Where(org => org.Type == OrgType.School))
        {
        }

        public IQuery<Models.Course> GetCoursesForSchool(string orgId)
        {
            return Context.Courses
                .Where(course => course.OrgId == orgId)
                .UseAsDataSource(Mapper)
                .For<Models.Course>()
                .ToBaseQuery();
        }

        public IQuery<Models.Class> GetClassesForSchool(string orgId)
        {
            return Context.Classes
                .Where(@class => @class.SchoolId == orgId)
                .UseAsDataSource(Mapper)
                .For<Models.Class>()
                .ToBaseQuery();
        }

        public IQuery<Models.Enrollment> GetEnrollmentsForClassInSchool(string orgId, string classId)
        {
            return Context.Enrollments
                .Where(enrollment => enrollment.Class.SchoolId == orgId && enrollment.ClassId == classId)
                .UseAsDataSource(Mapper)
                .For<Models.Enrollment>()
                .ToBaseQuery();
        }

        public IQuery<Models.User> GetStudentsForClassInSchool(string orgId, string classId)
        {
            return Context.Users
                .Where(user => user.Type == UserType.Student && user.Enrollments.Any(enrollment => enrollment.Class.SchoolId == orgId && enrollment.ClassId == classId))
                .UseAsDataSource(Mapper)
                .For<Models.User>()
                .ToBaseQuery();
        }

        public IQuery<Models.User> GetTeachersForClassInSchool(string orgId, string classId)
        {
            return Context.Users
                .Where(user => user.Type == UserType.Teacher && user.Enrollments.Any(enrollment => enrollment.Class.SchoolId == orgId && enrollment.ClassId == classId))
                .UseAsDataSource(Mapper)
                .For<Models.User>()
                .ToBaseQuery();
        }

        public IQuery<Models.Enrollment> GetEnrollmentsForSchool(string orgId)
        {
            return Context.Enrollments
                .Where(enrollment => enrollment.Class.SchoolId == orgId)
                .UseAsDataSource(Mapper)
                .For<Models.Enrollment>()
                .ToBaseQuery();
        }

        public IQuery<Models.User> GetStudentsForSchool(string orgId)
        {
            return Context.Users
                .Where(user => user.Type == UserType.Student && user.Orgs.Any(org => org.OrgId == orgId))
                .UseAsDataSource(Mapper)
                .For<Models.User>()
                .ToBaseQuery();
        }

        public IQuery<Models.User> GetTeachersForSchool(string orgId)
        {
            return Context.Users
                .Where(user => user.Type == UserType.Teacher && user.Orgs.Any(org => org.OrgId == orgId))
                .UseAsDataSource(Mapper)
                .For<Models.User>()
                .ToBaseQuery();
        }

        public IQuery<Models.AcademicSession> GetTermsForSchool(string orgId)
        {
            return Context.AcademicSessions
                .Where(session => session.Type == AcademicSessionType.Term && session.Classes.Any(org => org.Class.SchoolId == orgId))
                .UseAsDataSource(Mapper)
                .For<Models.AcademicSession>()
                .ToBaseQuery();
        }
    }
}