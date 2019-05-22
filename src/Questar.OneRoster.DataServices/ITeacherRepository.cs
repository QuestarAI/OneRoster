namespace Questar.OneRoster.DataServices
{
    using Models;

    public interface ITeacherRepository : IRepository<User>
    {
        IQuery<Class> GetClassesForTeacher(string userId);
    }
}