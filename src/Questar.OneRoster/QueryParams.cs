namespace Questar.OneRoster
{
    using System.Collections.Generic;

    public abstract class QueryParams
    {
        public IList<string> Fields { get; set; }
    }
}