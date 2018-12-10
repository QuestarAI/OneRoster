namespace Questar.OneRoster.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Filtering;
    using Sorting;

    public interface IQuery<T> : IQuery
    {
        IDynamicQuery Fields(IEnumerable<string> fields);

        IOrderedQuery<T> Sort(string field, SortDirection? direction = SortDirection.Asc);

        IQuery<T> Where(FilterExpression<T> filter);

        IQuery<T> WhereHasKey(object key);

        new T Single();

        new Task<T> SingleAsync();

        new IList<T> ToList();

        new Task<IList<T>> ToListAsync();
    }
}