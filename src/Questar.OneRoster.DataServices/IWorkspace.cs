using System;
using System.Threading.Tasks;

namespace Questar.OneRoster.DataServices
{
    public interface IWorkspace : IDisposable
    {
        void Save();

        Task SaveAsync();
    }
}