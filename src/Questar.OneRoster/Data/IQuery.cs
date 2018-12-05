namespace Questar.OneRoster.Data
{
    using System.Collections.Generic;

    public interface IQuery
    {
        IQuery Fields(IEnumerable<string> fields);
    }
}