namespace Questar.OneRoster.Client
{
    using System.Threading.Tasks;

    public interface IEditEndpoint<T> : IItemEndpoint<T>
    {
        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync();
    }
}