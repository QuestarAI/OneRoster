namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Filtering;
    using Sorting;

    public class Query<T> : IQuery<T>
    {
        public Query(IQueryable<T> source, Func<T, object> keySelector, Func<object, object, bool> keyComparer)
        {
            Source = source;
            KeySelector = keySelector;
            KeyComparer = keyComparer;
        }

        protected IQueryable<T> Source { get; }

        protected Func<T, object> KeySelector { get; }

        protected Func<object, object, bool> KeyComparer { get; }

        protected virtual IDynamicQuery ToDynamicQuery(IEnumerable<string> fields) => new DynamicQuery<T>(Source, fields);

        public IDynamicQuery Fields(IEnumerable<string> fields) => ToDynamicQuery(fields);

        public virtual T Single() => Source.Single();

        public virtual Task<T> SingleAsync() => Task.FromResult(Source.Single());

        IList<T> IQuery<T>.ToList() => ToList();

        async Task<IList<T>> IQuery<T>.ToListAsync() => await ToListAsync();

        public virtual IQuery<T> Where(FilterExpression<T> predicate) => new Query<T>(Source.Where(predicate), KeySelector, KeyComparer);

        public virtual IQuery<T> WhereHasKey(object key) => new Query<T>(Source.Where(source => KeyComparer(KeySelector(source), key)), KeySelector, KeyComparer);

        public virtual IOrderedQuery<T> Sort(string field, SortDirection? direction) => new OrderedQuery<T>(Source.SortBy(field, direction), KeySelector, KeyComparer);

        object IQuery.Single() => Single();

        async Task<object> IQuery.SingleAsync() => await SingleAsync();

        IList IQuery.ToList() => ToList();

        async Task<IList> IQuery.ToListAsync() => await ToListAsync();

        public virtual List<T> ToList() => Source.ToList();

        public virtual Task<List<T>> ToListAsync() => Source.ToAsyncEnumerable().ToList();
    }
}