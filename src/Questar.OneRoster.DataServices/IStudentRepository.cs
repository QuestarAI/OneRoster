using Questar.OneRoster.Models;

namespace Questar.OneRoster.DataServices
{
    public interface IStudentRepository : IRepository<User>
    {
        IQuery<Class> GetClassesForStudent(string userId);
    }
}