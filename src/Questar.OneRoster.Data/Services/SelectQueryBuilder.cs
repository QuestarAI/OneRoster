namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Filtering;
    using Models;
    using OneRoster.Collections;
    using Sorting;

    public class SelectQueryBuilder<T> : QueryBuilder, ISelectQueryBuilder<T> where T : Base
    {
        private Filter _filter;

        private int _pageLimit;

        private int _pageOffset;

        private string _sortField;

        private SortDirection? _sortDirection;

        public SelectQueryBuilder(IQueryable<T> source) => Source = source;

        public IQueryable<T> Source { get; }

        public IPage<T> Query() => throw new NotImplementedException();

        public Task<IPage<T>> QueryAsync() => throw new NotImplementedException();

        public ISelectQueryBuilder<T> Filter(Filter value)
        {
            _filter = value;
            return this;
        }

        public ISelectQueryBuilder<T> Limit(int value)
        {
            _pageLimit = value;
            return this;
        }

        public ISelectQueryBuilder<T> Offset(int value)
        {
            _pageOffset = value;
            return this;
        }

        public ISelectQueryBuilder<T> Sort(string field, SortDirection? direction)
        {
            _sortField = field;
            _sortDirection = direction;
            return this;
        }

        IPage<object> ISelectQueryBuilder.Query() => Query();

        async Task<IPage<object>> ISelectQueryBuilder.QueryAsync() => await QueryAsync();

        public new ISelectQueryBuilder Fields(string[] fields) => (ISelectQueryBuilder) base.Fields(fields);
    }
}