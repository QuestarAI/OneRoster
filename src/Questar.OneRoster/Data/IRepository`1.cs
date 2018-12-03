namespace Questar.OneRoster.Data
{
    using System.Threading.Tasks;
    using Collections;

    public interface IRepository<T> : IRepository
    {
        Task Upsert(T entity);

        Task Delete(T entity);

        Task<T> Single(SingleQueryParams @params);

        Task<Page<T>> Select(SelectQueryParams @params);
    }
}