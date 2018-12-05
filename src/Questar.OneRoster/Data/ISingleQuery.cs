namespace Questar.OneRoster.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISingleQuery : IQuery
    {
        new ISingleQuery Fields(IEnumerable<string> fields);

        object ToObject(Guid id);

        Task<object> ToObjectAsync(Guid id);
    }
}