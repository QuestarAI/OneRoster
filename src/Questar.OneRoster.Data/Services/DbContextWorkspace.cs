namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class DbContextWorkspace<TContext> : IWorkspace where TContext : DbContext
    {
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public DbContextWorkspace(TContext context)
            => Context = context;

        protected TContext Context { get; }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.TryGetValue(typeof(T), out var repository))
                return repository as IRepository<T>;
            _repositories.Add(typeof(T), repository = new DbSetRepository<T>(Context.Set<T>()));
            return (IRepository<T>) repository;
        }

        public void Save()
            => Context.SaveChanges();

        public Task SaveAsync()
            => Context.SaveChangesAsync();

        public void Dispose()
            => Context.Dispose();
    }
}