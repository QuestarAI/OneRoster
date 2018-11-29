using System;
using System.Collections.Generic;

namespace Questar.OneRoster
{
    using System.Linq;
    using Collections;
    using Filtering;
    using Sorting;

    public class QueryBuilder<T>
    {
        public QueryBuilder<T> Filter(Filter filter)
        {
            throw new NotImplementedException();
        }

        public QueryBuilder<T> Fields(IEnumerable<string> fields)
        {
            throw new NotImplementedException();
        }

        public QueryBuilder<T> Fields(params string[] fields)
            => Fields(fields.AsEnumerable());

        public QueryBuilder<T> SortBy(string field, SortDirection? direction = null)
        {
            throw new NotImplementedException();
        }

        public Page<T> ToPage(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public T Single(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
