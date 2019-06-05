using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Questar.OneRoster.DataServices.EntityFrameworkCore
{
    public class BaseWorkspace<TContext> : Workspace
        where TContext : DbContext
    {
        public BaseWorkspace(TContext context)
        {
            Context = context;
        }

        protected TContext Context { get; }

        public override void Save()
        {
            Context.SaveChanges();
        }

        public override Task SaveAsync()
        {
            return Context.SaveChangesAsync();
        }

        public override void Dispose()
        {
            Context.Dispose();
        }
    }
}