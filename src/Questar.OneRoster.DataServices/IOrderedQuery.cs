namespace Questar.OneRoster.DataServices
{
    using System.Threading.Tasks;
    using Collections;

    public interface IOrderedQuery : IQuery
    {
        IPage ToPage(int offset, int limit);

        Task<IPage> ToPageAsync(int offset, int limit);
    }
}