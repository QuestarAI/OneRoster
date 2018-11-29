using System.Collections.Generic;

namespace Questar.OneRoster
{
    using Filtering;
    using Sorting;

    public class QueryParams
    {
        public IList<string> Fields { get; set; }
    }

    public class SelectQueryParams : QueryParams
    {
        public Filter Filter { get; set; }

        public int PageOffset { get; set; }

        public int PageLimit { get; set; }

        public string SortField { get; set; }

        public SortDirection? SortDirection { get; set; }
    }

    public class SingleQueryParams : QueryParams
    {
        public object Id { get; set; }
    }
}
