namespace Questar.OneRoster.Data
{
    using System;
    using System.Threading.Tasks;

    public sealed class ReadOnlyRepository<T> : IRepository<T>
    {
        public ReadOnlyRepository(IRepository<T> repository) => Repository = repository;

        private IRepository<T> Repository { get; }

        public int Count() => Repository.Count();

        public Task<int> CountAsync() => Repository.CountAsync();

        bool IRepository.IsReadOnly => true;

        Task IRepository<T>.Upsert(T entity) => throw new NotSupportedException("The repository is read-only.");

        Task IRepository<T>.Delete(T entity) => throw new NotSupportedException("The repository is read-only.");

        public ISingleQueryBuilder<T> Single() => Repository.Single();

        public ISelectQueryBuilder<T> Select() => Repository.Select();
    }
}