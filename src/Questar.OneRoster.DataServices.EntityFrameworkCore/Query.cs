namespace Questar.OneRoster.DataServices.EntityFrameworkCore
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Collections;
    using Filtering;
    using Sorting;

    public abstract class Query<T> : IQuery<T>
    {
        protected Query(IQueryable<T> source) => Source = source;

        protected IQueryable<T> Source { get; }

        public virtual IQuery<dynamic> Select(IEnumerable<string> properties)
            => Select(properties.Select(property => typeof(T).GetProperty(property, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)).ToArray());

        public abstract IQuery<dynamic> Select(PropertyInfo[] properties);

        public virtual T Single()
            => Source.Single();

        public virtual Task<T> SingleAsync()
            => Task.FromResult(Source.Single());

        public abstract IQuery<T> Sort(string field, SortDirection? direction);

        public abstract IQuery<T> Where(Filter predicate);

        public abstract IQuery<T> WhereHasSourcedId(string sourcedId);

        public virtual List<T> ToList()
            => Source.ToList();

        public virtual Task<List<T>> ToListAsync()
            => Source.ToAsyncEnumerable().ToList();

        public Page<T> ToPage(int offset, int limit)
        {
            var count = Source.Count();
            var items = Source.Skip(offset).Take(limit).ToList();
            return new Page<T>(count, items);
        }

        public async Task<Page<T>> ToPageAsync(int offset, int limit)
        {
            var count = Source.Count();
            var items = Source.Skip(offset).Take(limit).ToAsyncEnumerable().ToList();
            return new Page<T>(count, await items);
        }

        #region IQuery<T>

        IList<T> IQuery<T>.ToList()
            => ToList();

        async Task<IList<T>> IQuery<T>.ToListAsync()
            => await ToListAsync();

        IPage<T> IQuery<T>.ToPage(int offset, int limit)
            => ToPage(offset, limit);

        async Task<IPage<T>> IQuery<T>.ToPageAsync(int offset, int limit)
            => await ToPageAsync(offset, limit);

        #endregion

        #region IQuery

        IQuery IQuery.Sort(string field, SortDirection? direction)
            => Sort(field, direction);

        object IQuery.Single()
            => Single();

        async Task<object> IQuery.SingleAsync()
            => await SingleAsync();

        IList IQuery.ToList()
            => ToList();

        async Task<IList> IQuery.ToListAsync()
            => await ToListAsync();

        IPage IQuery.ToPage(int offset, int limit)
            => ToPage(offset, limit);

        async Task<IPage> IQuery.ToPageAsync(int offset, int limit)
            => await ToPageAsync(offset, limit);

        IQuery IQuery.Where(Filter filter)
            => Where(filter);

        IQuery IQuery.WhereHasSourcedId(string sourcedId)
            => WhereHasSourcedId(sourcedId);

        #endregion
    }
}