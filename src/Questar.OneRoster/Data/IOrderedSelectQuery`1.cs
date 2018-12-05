namespace Questar.OneRoster.Data
{
    using System.Threading.Tasks;
    using Collections;

    public interface IOrderedSelectQuery<T> : IOrderedSelectQuery
    {
        new IPage<T> ToPage(int offset, int limit);

        new Task<IPage<T>> ToPageAsync(int offset, int limit);
    }
}