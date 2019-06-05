using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Questar.OneRoster.Collections;
using Questar.OneRoster.Filtering;
using Questar.OneRoster.Sorting;

namespace Questar.OneRoster.DataServices
{
    public interface IQuery
    {
        IQuery<dynamic> Select(IEnumerable<string> fields);

        IQuery<dynamic> Select(PropertyInfo[] fields);

        IQuery Sort(string field, SortDirection? direction = SortDirection.Asc);

        object Single();

        Task<object> SingleAsync();

        IList ToList();

        Task<IList> ToListAsync();

        IPage ToPage(int offset, int limit);

        Task<IPage> ToPageAsync(int offset, int limit);

        IQuery Where(Filter filter);

        IQuery WhereHasSourcedId(string sourcedId);
    }
}