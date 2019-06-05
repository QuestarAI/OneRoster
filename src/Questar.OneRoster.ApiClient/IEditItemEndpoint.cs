using System.Threading.Tasks;

namespace Questar.OneRoster.ApiClient
{
    public interface IEditItemEndpoint<T> : IItemEndpoint<T>
    {
        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync();
    }
}