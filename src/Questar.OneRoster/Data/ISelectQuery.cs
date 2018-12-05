namespace Questar.OneRoster.Data
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Filtering;
    using Sorting;

    public interface ISelectQuery : IQuery
    {
        new ISelectQuery Fields(IEnumerable<string> fields);

        ISelectQuery Filter(Filter filter);

        IOrderedSelectQuery Sort(string field, SortDirection? direction = SortDirection.Asc);

        IList ToList();

        Task<IList> ToListAsync();
    }
}