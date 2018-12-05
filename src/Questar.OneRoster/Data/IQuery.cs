namespace Questar.OneRoster.Data
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IQuery
    {
        IQuery Fields(IEnumerable<string> fields);

        object Single();

        Task<object> SingleAsync();

        IList ToList();

        Task<IList> ToListAsync();
    }
}