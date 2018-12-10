namespace Questar.OneRoster.Data.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public abstract class DbSetRepository<T> : Repository<T>
        where T : class
    {
        protected DbSetRepository(DbSet<T> set) => Set = set;

        public DbSet<T> Set { get; }

        public override async Task UpsertAsync(T entity)
        {
            var item = await Set.FindAsync(GetKey(entity));
            if (item == null)
                await Set.AddAsync(entity);
        }

        public abstract object[] GetKey(T entity);

        public override Task DeleteAsync(T entity)
        {
            Set.Remove(entity);
            return Task.CompletedTask;
        }

        public override IQueryable<T> AsQueryable() => Set;
    }
}