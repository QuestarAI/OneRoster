namespace Questar.OneRoster.Data
{
    using System.Threading.Tasks;
    using Collections;
    using Filtering;
    using Sorting;

    public interface ISelectQueryBuilder<T> : ISelectQueryBuilder
    {
        ISelectQueryBuilder<T> Filter(Filter value);

        ISelectQueryBuilder<T> Limit(int value);

        ISelectQueryBuilder<T> Offset(int value);

        ISelectQueryBuilder<T> Sort(string field, SortDirection? direction = SortDirection.Asc);

        new IPage<T> Query();

        new Task<IPage<T>> QueryAsync();
    }
}