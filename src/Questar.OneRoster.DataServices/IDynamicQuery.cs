namespace Questar.OneRoster.DataServices
{
    using System.Collections.Generic;

    public interface IDynamicQuery : IQuery
    {
        IEnumerable<string> Members { get; }
    }
}