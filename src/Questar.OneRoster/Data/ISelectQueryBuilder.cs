namespace Questar.OneRoster.Data
{
    using System.Threading.Tasks;
    using Collections;

    public interface ISelectQueryBuilder : IQueryBuilder
    {
        new ISelectQueryBuilder Fields(string[] fields);

        IPage<object> Query();

        Task<IPage<object>> QueryAsync();
    }
}