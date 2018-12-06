namespace Questar.OneRoster.Data
{
    using System.Threading.Tasks;

    public interface IWorkspace
    {
        IRepository<T> GetRepository<T>();

        void Save();

        Task SaveAsync();
    }
}