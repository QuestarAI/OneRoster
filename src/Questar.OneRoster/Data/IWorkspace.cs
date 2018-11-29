namespace Questar.OneRoster.Data
{
    using System.Threading.Tasks;

    public interface IWorkspace
    {
        IRepository<T> GetRepository<T>() where T : class;

        void Save();

        Task SaveAsync();
    }
}