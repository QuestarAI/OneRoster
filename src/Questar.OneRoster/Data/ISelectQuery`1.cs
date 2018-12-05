namespace Questar.OneRoster.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Filtering;
    using Sorting;

    public interface ISelectQuery<T> : ISelectQuery
    {
        new ISelectQuery<T> Filter(Filter filter);

        new IOrderedSelectQuery<T> Sort(string field, SortDirection? direction = SortDirection.Asc);

        new IList<T> ToList();

        new Task<IList<T>> ToListAsync();
    }
}