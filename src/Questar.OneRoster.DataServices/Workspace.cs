namespace Questar.OneRoster.DataServices
{
    using System.Threading.Tasks;

    public abstract class Workspace : IWorkspace
    {
        public abstract void Save();

        public abstract Task SaveAsync();

        public virtual void Dispose()
        {
        }
    }
}