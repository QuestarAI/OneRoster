namespace Questar.OneRoster.DataServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Collections;
    using Filtering;
    using Models;
    using Sorting;

    public interface IQuery<T> : IQuery
    {
        new IQuery<T> Sort(string field, SortDirection? direction = SortDirection.Asc);

        new IQuery<T> Where(Filter filter);

        new IQuery<T> WhereHasSourcedId(string sourcedId);

        new T Single();

        new Task<T> SingleAsync();

        new IList<T> ToList();

        new Task<IList<T>> ToListAsync();

        new IPage<T> ToPage(int offset, int limit);

        new Task<IPage<T>> ToPageAsync(int offset, int limit);
    }
}