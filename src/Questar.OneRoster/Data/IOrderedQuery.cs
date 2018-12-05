namespace Questar.OneRoster.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Collections;

    public interface IOrderedQuery : IQuery
    {
        new IOrderedQuery Fields(IEnumerable<string> fields);

        IPage ToPage(int offset, int limit);

        Task<IPage> ToPageAsync(int offset, int limit);
    }
}