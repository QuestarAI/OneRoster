namespace Questar.OneRoster.Data.Services
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class DbContextWorkspace<TContext> : Workspace where TContext : DbContext
    {
        public DbContextWorkspace(TContext context) => Context = context;

        protected TContext Context { get; }

        public override void Save() => Context.SaveChanges();

        public override Task SaveAsync() => Context.SaveChangesAsync();

        public virtual void Dispose() => Context.Dispose();
    }
}