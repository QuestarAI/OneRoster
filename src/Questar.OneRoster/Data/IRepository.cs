namespace Questar.OneRoster.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepository : IQueryable
    {
        bool IsReadOnly { get; }

        int Count();

        Task<int> CountAsync();
    }
}