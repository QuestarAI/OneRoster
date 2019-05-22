namespace Questar.OneRoster.DataServices.EntityFrameworkCore
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class BaseWorkspace<TContext> : Workspace
        where TContext : DbContext
    {
        public BaseWorkspace(TContext context)
            => Context = context;

        protected TContext Context { get; }

        public override void Save()
            => Context.SaveChanges();

        public override Task SaveAsync()
            => Context.SaveChangesAsync();

        public override void Dispose()
            => Context.Dispose();
    }
}