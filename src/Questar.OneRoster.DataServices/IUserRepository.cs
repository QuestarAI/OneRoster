using Questar.OneRoster.Models;

namespace Questar.OneRoster.DataServices
{
    public interface IUserRepository : IRepository<User>
    {
        IQuery<Class> GetClassesForUser(string userId);
    }
}