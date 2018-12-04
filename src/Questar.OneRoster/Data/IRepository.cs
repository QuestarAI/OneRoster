namespace Questar.OneRoster.Data
{
    using System.Threading.Tasks;

    public interface IRepository
    {
        bool IsReadOnly { get; }

        int Count();

        Task<int> CountAsync();
    }
}