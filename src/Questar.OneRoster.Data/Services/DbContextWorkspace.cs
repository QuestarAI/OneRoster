namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class DbContextWorkspace<TContext> : IWorkspace where TContext : DbContext
    {
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public DbContextWorkspace(TContext context)
            => Context = context;

        protected TContext Context { get; }

        public virtual IRepository<T> GetRepository<T>() where T : Base
        {
            if (_repositories.TryGetValue(typeof(T), out var repository))
                return repository as IRepository<T>;
            _repositories.Add(typeof(T), repository = new DbSetRepository<T>(Context.Set<T>()));
            return (IRepository<T>) repository;
        }

        public virtual void Save()
            => Context.SaveChanges();

        public virtual Task SaveAsync()
            => Context.SaveChangesAsync();

        public virtual void Dispose()
            => Context.Dispose();
    }
}