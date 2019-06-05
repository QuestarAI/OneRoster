using System;
using System.Threading.Tasks;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.DataServices
{
    public sealed class ReadOnlyRepository<T> : IRepository<T>
        where T : Base
    {
        public ReadOnlyRepository(IRepository<T> repository)
        {
            Repository = repository;
        }

        private IRepository<T> Repository { get; }

        public int Count()
        {
            return Repository.Count();
        }

        public Task<int> CountAsync()
        {
            return Repository.CountAsync();
        }

        public IQuery<T> AsQuery()
        {
            return Repository.AsQuery();
        }

        IQuery IRepository.AsQuery()
        {
            return AsQuery();
        }

        Type IRepository.Type => Repository.Type;

        bool IRepository.IsReadOnly => true;

        Task IRepository<T>.UpsertAsync(T entity)
        {
            throw new NotSupportedException("The repository is read-only.");
        }

        Task IRepository<T>.DeleteAsync(T entity)
        {
            throw new NotSupportedException("The repository is read-only.");
        }
    }
}