namespace Questar.OneRoster.Data
{
    using System.Threading.Tasks;

    public interface IRepository<T> : IRepository
    {
        Task Upsert(T entity);

        Task Delete(T entity);

        ISingleQueryBuilder<T> Single();

        ISelectQueryBuilder<T> Select();
    }
}