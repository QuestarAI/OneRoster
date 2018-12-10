namespace Questar.OneRoster.DataServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Collections;

    public interface IOrderedQuery<T> : IOrderedQuery, IQuery<T>
    {
        new IOrderedDynamicQuery Fields(IEnumerable<string> fields);

        new IPage<T> ToPage(int offset, int limit);

        new Task<IPage<T>> ToPageAsync(int offset, int limit);
    }
}