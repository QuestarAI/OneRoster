namespace Questar.OneRoster.Data
{
    using System.Collections.Generic;

    public interface IDynamicQuery : IQuery
    {
        IEnumerable<string> Members { get; }
    }
}