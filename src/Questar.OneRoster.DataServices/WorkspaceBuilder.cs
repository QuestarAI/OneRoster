namespace Questar.OneRoster.Data.Services
{
    using System.Collections.Generic;

    public class WorkspaceBuilder
    {
        protected List<IRepository> Repositories { get; } = new List<IRepository>();

        public void Add<T>(IRepository<T> repository) => Repositories.Add(repository);

        public IReadOnlyCollection<IRepository> GetRepositories() => Repositories.AsReadOnly();
    }
}