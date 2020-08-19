using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Questar.OneRoster.Collections;
using Questar.OneRoster.Filtering;
using Questar.OneRoster.Sorting;

namespace Questar.OneRoster.DataServices.EntityFrameworkCore
{
    public abstract class Query<T> : IQuery<T>
    {
        protected Query(IQueryable<T> source)
        {
            Source = source;
        }

        protected IQueryable<T> Source { get; }

        public virtual IQuery<dynamic> Select(IEnumerable<string> properties)
        {
            return Select(properties.Select(property => typeof(T).GetProperty(property, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)).ToArray());
        }

        public abstract IQuery<dynamic> Select(PropertyInfo[] properties);

        public virtual T Single()
        {
            return Source.Single();
        }

        public virtual Task<T> SingleAsync()
        {
            return Task.FromResult(Source.Single());
        }

        public abstract IQuery<T> Sort(string field, SortDirection? direction);

        public abstract IQuery<T> Where(Filter predicate);

        public abstract IQuery<T> WhereHasSourcedId(string sourcedId);

        public virtual List<T> ToList()
        {
            return Source.ToList();
        }

        public virtual Task<List<T>> ToListAsync()
        {
            return Task.FromResult(ToList());
        }

        public virtual Page<T> ToPage(int offset, int limit)
        {
            var count = Source.Count();
            var items = Source.Skip(offset).Take(limit).ToList();
            return new Page<T>(count, items);
        }

        public virtual Task<Page<T>> ToPageAsync(int offset, int limit)
        {
            return Task.FromResult(ToPage(offset, limit));
        }

        #region IQuery<T>

        IList<T> IQuery<T>.ToList()
        {
            return ToList();
        }

        async Task<IList<T>> IQuery<T>.ToListAsync()
        {
            return await ToListAsync();
        }

        IPage<T> IQuery<T>.ToPage(int offset, int limit)
        {
            return ToPage(offset, limit);
        }

        async Task<IPage<T>> IQuery<T>.ToPageAsync(int offset, int limit)
        {
            return await ToPageAsync(offset, limit);
        }

        #endregion

        #region IQuery

        IQuery IQuery.Sort(string field, SortDirection? direction)
        {
            return Sort(field, direction);
        }

        object IQuery.Single()
        {
            return Single();
        }

        async Task<object> IQuery.SingleAsync()
        {
            return await SingleAsync();
        }

        IList IQuery.ToList()
        {
            return ToList();
        }

        async Task<IList> IQuery.ToListAsync()
        {
            return await ToListAsync();
        }

        IPage IQuery.ToPage(int offset, int limit)
        {
            return ToPage(offset, limit);
        }

        async Task<IPage> IQuery.ToPageAsync(int offset, int limit)
        {
            return await ToPageAsync(offset, limit);
        }

        IQuery IQuery.Where(Filter filter)
        {
            return Where(filter);
        }

        IQuery IQuery.WhereHasSourcedId(string sourcedId)
        {
            return WhereHasSourcedId(sourcedId);
        }

        #endregion
    }
}