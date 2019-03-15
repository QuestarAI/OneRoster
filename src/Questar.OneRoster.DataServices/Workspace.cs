namespace Questar.OneRoster.DataServices
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class Workspace : IWorkspace
    {
        protected Workspace() => Repositories = new Lazy<ReadOnlyDictionary<Type, IRepository>>(Configure);

        protected Lazy<ReadOnlyDictionary<Type, IRepository>> Repositories { get; }

        public virtual IRepository<T> GetRepository<T>() => (IRepository<T>) Repositories.Value[typeof(T)];

        public abstract void Save();

        public abstract Task SaveAsync();

        private ReadOnlyDictionary<Type, IRepository> Configure()
        {
            var builder = new WorkspaceBuilder();
            Configure(builder);
            var repositories = builder.GetRepositories().ToDictionary(repository => repository.Type);
            return new ReadOnlyDictionary<Type, IRepository>(repositories);
        }

        protected virtual void Configure(WorkspaceBuilder builder)
        {
        }
    }
}