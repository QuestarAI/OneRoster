namespace Questar.OneRoster.DataServices
{
    using Models;

    public interface IStudentRepository : IRepository<User>
    {
        IQuery<Class> GetClassesForStudent(string userId);
    }
}