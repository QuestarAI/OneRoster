namespace Questar.OneRoster.DataServices
{
    using System.Threading.Tasks;

    public interface IWorkspace
    {
        void Save();

        Task SaveAsync();
    }
}