namespace Questar.OneRoster.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using Collections;

    public interface IRepository<T> : IRepository, IQueryable<T>
    {
        void Add(T entity);

        void Remove(T entity);

        Task<T> Single(SingleQueryParams @params);

        Task<Page<T>> Select(SelectQueryParams @params);
    }
}