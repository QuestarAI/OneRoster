using Questar.OneRoster.Models;

namespace Questar.OneRoster.DataServices
{
    public interface ICourseRepository : IRepository<Course>
    {
        IQuery<Class> GetClassesForCourse(string courseId);

        IQuery<Resource> GetResourcesForCourse(string courseId);
    }
}