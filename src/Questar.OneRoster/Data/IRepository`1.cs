namespace Questar.OneRoster.Data
{
    using System.Linq;

    public interface IRepository<T> : IRepository, IQueryable<T>
    {
        void Add(T entity);

        void Remove(T entity);
    }
}