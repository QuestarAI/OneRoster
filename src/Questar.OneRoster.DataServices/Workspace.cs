using System.Threading.Tasks;

namespace Questar.OneRoster.DataServices
{
    public abstract class Workspace : IWorkspace
    {
        public abstract void Save();

        public abstract Task SaveAsync();

        public virtual void Dispose()
        {
        }
    }
}