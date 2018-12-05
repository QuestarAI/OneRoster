namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Filtering;
    using Sorting;

    public class SelectQuery<T> : Query, ISelectQuery<T>
    {
        public SelectQuery(IQueryable<T> source) => Source = source;

        public IQueryable<T> Source { get; private set; }

        public new ISelectQuery Fields(IEnumerable<string> fields) => (ISelectQuery) base.Fields(fields);

        public ISelectQuery<T> Filter(Filter filter)
        {
            Source = Source.Where(filter.ToFilterExpression<T>());
            return this;
        }

        public IOrderedSelectQuery<T> Sort(string field, SortDirection? direction)
        {
            Source = Source.SortBy(field, direction);
            return new OrderedSelectQuery<T>(this);
        }

        public IList<T> ToList() => throw new NotImplementedException();

        public Task<IList<T>> ToListAsync() => throw new NotImplementedException();

        ISelectQuery ISelectQuery.Filter(Filter filter) => Filter(filter);

        IOrderedSelectQuery ISelectQuery.Sort(string field, SortDirection? direction) => Sort(field, direction);

        IList ISelectQuery.ToList() => throw new NotImplementedException();

        Task<IList> ISelectQuery.ToListAsync() => throw new NotImplementedException();
    }
}