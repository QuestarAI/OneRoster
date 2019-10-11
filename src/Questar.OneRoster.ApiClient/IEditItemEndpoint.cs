using System.Threading.Tasks;

namespace Questar.OneRoster.ApiClient
{
    public interface IEditItemEndpoint<T> : IItemEndpoint<T>
    {
        Task UpsertAsync(T entity);

        Task DeleteAsync();
    }
}