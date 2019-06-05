using Questar.OneRoster.Models;

namespace Questar.OneRoster.DataServices
{
    public interface ITeacherRepository : IRepository<User>
    {
        IQuery<Class> GetClassesForTeacher(string userId);
    }
}