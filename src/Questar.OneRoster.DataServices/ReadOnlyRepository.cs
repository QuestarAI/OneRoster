namespace Questar.OneRoster.DataServices
{
    using System;
    using System.Threading.Tasks;
    using Models;

    public sealed class ReadOnlyRepository<T> : IRepository<T>
        where T : Base
    {
        public ReadOnlyRepository(IRepository<T> repository)
            => Repository = repository;

        private IRepository<T> Repository { get; }

        public int Count()
            => Repository.Count();

        public Task<int> CountAsync()
            => Repository.CountAsync();

        public IQuery<T> AsQuery()
            => Repository.AsQuery();

        IQuery IRepository.AsQuery()
            => AsQuery();

        Type IRepository.Type
            => Repository.Type;

        bool IRepository.IsReadOnly
            => true;

        Task IRepository<T>.UpsertAsync(T entity)
            => throw new NotSupportedException("The repository is read-only.");

        Task IRepository<T>.DeleteAsync(T entity)
            => throw new NotSupportedException("The repository is read-only.");
    }
}