namespace Questar.OneRoster.Data
{
    using System.Threading.Tasks;
    using Models;

    public interface IWorkspace
    {
        IRepository<T> GetRepository<T>() where T : Base;

        void Save();

        Task SaveAsync();
    }
}