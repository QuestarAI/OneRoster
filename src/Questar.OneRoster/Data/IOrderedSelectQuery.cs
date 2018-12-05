namespace Questar.OneRoster.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Collections;

    public interface IOrderedSelectQuery : ISelectQuery
    {
        new IOrderedSelectQuery Fields(IEnumerable<string> fields);

        IPage ToPage(int offset, int limit);

        Task<IPage> ToPageAsync(int offset, int limit);
    }
}