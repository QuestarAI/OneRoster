namespace Questar.OneRoster.Data
{
    using System;
    using System.Threading.Tasks;

    public interface ISingleQueryBuilder<T> : ISingleQueryBuilder
    {
        new T Query(Guid sourcedId);

        new Task<T> QueryAsync(Guid sourcedId);
    }
}