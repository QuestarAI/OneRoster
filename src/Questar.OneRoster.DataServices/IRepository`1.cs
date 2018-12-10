namespace Questar.OneRoster.DataServices
{
    using System.Threading.Tasks;

    public interface IRepository<T> : IRepository
    {
        Task UpsertAsync(T entity);

        Task DeleteAsync(T entity);

        new IQuery<T> AsQuery();
    }
}