namespace Questar.OneRoster.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public sealed class ReadOnlyRepository<T> : IRepository<T>
    {
        public ReadOnlyRepository(IRepository<T> repository)
            => Repository = repository;

        private IRepository<T> Repository { get; }

        public int Count()
            => Repository.Count();

        public Task<int> CountAsync()
            => Repository.CountAsync();

        bool IRepository.IsReadOnly => true;

        void IRepository<T>.Add(T entity)
            => throw new NotSupportedException("The repository is read-only.");

        void IRepository<T>.Remove(T entity)
            => throw new NotSupportedException("The repository is read-only.");

        public IEnumerator<T> GetEnumerator()
            => Repository.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public Type ElementType => Repository.ElementType;

        public Expression Expression => Repository.Expression;

        public IQueryProvider Provider => Repository.Provider;
    }
}