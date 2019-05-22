namespace Questar.OneRoster.DataServices
{
    using Models;

    public interface ICourseRepository : IRepository<Course>
    {
        IQuery<Class> GetClassesForCourse(string courseId);

        IQuery<Resource> GetResourcesForCourse(string courseId);
    }
}