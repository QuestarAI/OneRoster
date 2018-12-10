namespace Questar.OneRoster.DataServices
{
    using System.Threading.Tasks;

    public interface IWorkspace
    {
        IRepository<T> GetRepository<T>();

        void Save();

        Task SaveAsync();
    }
}