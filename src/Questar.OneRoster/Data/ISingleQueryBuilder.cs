namespace Questar.OneRoster.Data
{
    using System;
    using System.Threading.Tasks;

    public interface ISingleQueryBuilder : IQueryBuilder
    {
        new ISingleQueryBuilder Fields(string[] fields);

        object Query(Guid id);

        Task<object> QueryAsync(Guid id);
    }
}