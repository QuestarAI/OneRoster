namespace Questar.OneRoster.ApiClient
{
    using System.Threading.Tasks;

    public interface IEditItemEndpoint<T> : IItemEndpoint<T>
    {
        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync();
    }
}