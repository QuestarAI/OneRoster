using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.DataServices
{
    public abstract class Repository<T> : IRepository<T>, IQueryable
        where T : Base
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType => AsQueryable().ElementType;

        public Expression Expression => AsQueryable().Expression;

        public IQueryProvider Provider => AsQueryable().Provider;

        Type IRepository.Type => typeof(T);

        bool IRepository.IsReadOnly => false;

        public int Count()
        {
            return AsQueryable().Count();
        }

        public virtual Task<int> CountAsync()
        {
            return Task.FromResult(Count());
        }

        public abstract Task DeleteAsync(T entity);

        public abstract IQuery<T> AsQuery();

        IQuery IRepository.AsQuery()
        {
            return AsQuery();
        }

        public abstract Task UpsertAsync(T entity);

        public abstract IQueryable<T> AsQueryable();

        public virtual IEnumerator<T> GetEnumerator()
        {
            return AsQueryable().GetEnumerator();
        }
    }
}