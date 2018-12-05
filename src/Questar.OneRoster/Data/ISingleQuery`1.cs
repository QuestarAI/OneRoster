namespace Questar.OneRoster.Data
{
    using System;
    using System.Threading.Tasks;

    public interface ISingleQuery<T> : ISingleQuery
    {
        new T ToObject(Guid id);

        new Task<T> ToObjectAsync(Guid id);
    }
}