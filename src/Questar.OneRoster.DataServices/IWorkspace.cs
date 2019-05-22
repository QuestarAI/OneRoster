namespace Questar.OneRoster.DataServices
{
    using System;
    using System.Threading.Tasks;

    public interface IWorkspace : IDisposable
    {
        void Save();

        Task SaveAsync();
    }
}