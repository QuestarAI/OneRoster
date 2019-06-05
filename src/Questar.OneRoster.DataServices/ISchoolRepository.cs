using Questar.OneRoster.Models;

namespace Questar.OneRoster.DataServices
{
    public interface ISchoolRepository : IRepository<Org>
    {
        IQuery<Course> GetCoursesForSchool(string orgId);

        IQuery<Class> GetClassesForSchool(string orgId);

        IQuery<Enrollment> GetEnrollmentsForClassInSchool(string orgId, string classId);

        IQuery<User> GetStudentsForClassInSchool(string orgId, string classId);

        IQuery<User> GetTeachersForClassInSchool(string orgId, string classId);

        IQuery<Enrollment> GetEnrollmentsForSchool(string orgId);

        IQuery<User> GetStudentsForSchool(string orgId);

        IQuery<User> GetTeachersForSchool(string orgId);

        IQuery<AcademicSession> GetTermsForSchool(string orgId);
    }
}