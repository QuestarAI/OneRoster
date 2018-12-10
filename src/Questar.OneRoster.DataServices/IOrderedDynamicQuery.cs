namespace Questar.OneRoster.Data
{
    using System.Threading.Tasks;
    using Collections;

    public interface IOrderedDynamicQuery : IDynamicQuery, IOrderedQuery
    {
        // TODO new dynamic Single();

        // TODO new Task<dynamic> SingleAsync();

        // TODO new IList<dynamic> ToList();

        // TODO new Task<IList<dynamic>> ToListAsync();

        new IPage<dynamic> ToPage(int offset, int limit);

        new Task<IPage<dynamic>> ToPageAsync(int offset, int limit);
    }
}