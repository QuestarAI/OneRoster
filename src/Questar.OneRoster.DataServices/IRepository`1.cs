namespace Questar.OneRoster.DataServices
{
    using System.Threading.Tasks;
    using Models;

    public interface IRepository<T> : IRepository
        where T : Base
    {
        Task UpsertAsync(T entity);

        Task DeleteAsync(T entity);

        new IQuery<T> AsQuery();
    }
}