namespace Questar.OneRoster.DataServices
{
    using System.Collections;
    using System.Threading.Tasks;

    public interface IQuery
    {
        object Single();

        Task<object> SingleAsync();

        IList ToList();

        Task<IList> ToListAsync();
    }
}