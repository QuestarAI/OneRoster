using System.Threading.Tasks;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.DataServices
{
    public interface IRepository<T> : IRepository
        where T : Base
    {
        Task UpsertAsync(T entity);

        Task DeleteAsync(T entity);

        new IQuery<T> AsQuery();
    }
}