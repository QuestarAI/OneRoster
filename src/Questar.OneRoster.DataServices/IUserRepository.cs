namespace Questar.OneRoster.DataServices
{
    using Models;

    public interface IUserRepository : IRepository<User>
    {
        IQuery<Class> GetClassesForUser(string userId);
    }
}