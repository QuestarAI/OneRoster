namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.Extensions.ExpressionMapping;
    using DataServices;
    using DataServices.EntityFrameworkCore;
    using Models;
    using AcademicSessionType = Data.AcademicSessionType;
    using Org = Data.Org;
    using OrgType = Data.OrgType;

    public class SchoolRepository : BaseRepository<Models.Org, Org>, ISchoolRepository
    {
        public SchoolRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper, context.Set<Org>().Where(org => org.Type == OrgType.School))
        {
        }

        public IQuery<Course> GetCoursesForSchool(string orgId)
            => Context.Courses
                .Where(course => course.OrgId == Guid.Parse(orgId))
                .UseAsDataSource(Mapper)
                .For<Course>()
                .ToBaseQuery();

        public IQuery<Class> GetClassesForSchool(string orgId)
            => Context.Classes
                .Where(@class => @class.SchoolId == Guid.Parse(orgId))
                .UseAsDataSource(Mapper)
                .For<Class>()
                .ToBaseQuery();

        public IQuery<Enrollment> GetEnrollmentsForClassInSchool(string orgId, string classId)
            => Context.Enrollments
                .Where(enrollment => enrollment.Class.SchoolId == Guid.Parse(orgId) && enrollment.ClassId == Guid.Parse(classId))
                .UseAsDataSource(Mapper)
                .For<Enrollment>()
                .ToBaseQuery();

        public IQuery<User> GetStudentsForClassInSchool(string orgId, string classId)
            => Context.Users
                .Where(user => user.Type == UserType.Student && user.Enrollments.Any(enrollment => enrollment.Class.SchoolId == Guid.Parse(orgId) && enrollment.ClassId == Guid.Parse(classId)))
                .UseAsDataSource(Mapper)
                .For<User>()
                .ToBaseQuery();

        public IQuery<User> GetTeachersForClassInSchool(string orgId, string classId)
            => Context.Users
                .Where(user => user.Type == UserType.Teacher && user.Enrollments.Any(enrollment => enrollment.Class.SchoolId == Guid.Parse(orgId) && enrollment.ClassId == Guid.Parse(classId)))
                .UseAsDataSource(Mapper)
                .For<User>()
                .ToBaseQuery();

        public IQuery<Enrollment> GetEnrollmentsForSchool(string orgId)
            => Context.Enrollments
                .Where(enrollment => enrollment.Class.SchoolId == Guid.Parse(orgId))
                .UseAsDataSource(Mapper)
                .For<Enrollment>()
                .ToBaseQuery();

        public IQuery<User> GetStudentsForSchool(string orgId)
            => Context.Users
                .Where(user => user.Type == UserType.Student && user.Orgs.Any(org => org.OrgId == Guid.Parse(orgId)))
                .UseAsDataSource(Mapper)
                .For<User>()
                .ToBaseQuery();

        public IQuery<User> GetTeachersForSchool(string orgId)
            => Context.Users
                .Where(user => user.Type == UserType.Teacher && user.Orgs.Any(org => org.OrgId == Guid.Parse(orgId)))
                .UseAsDataSource(Mapper)
                .For<User>()
                .ToBaseQuery();

        public IQuery<AcademicSession> GetTermsForSchool(string orgId)
            => Context.AcademicSessions
                .Where(session => session.Type == AcademicSessionType.Term && session.Classes.Any(org => org.Class.SchoolId == Guid.Parse(orgId)))
                .UseAsDataSource(Mapper)
                .For<AcademicSession>()
                .ToBaseQuery();
    }
}