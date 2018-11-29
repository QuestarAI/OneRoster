namespace Questar.OneRoster
{
    using Filtering;
    using Sorting;

    public class SelectQueryParams : QueryParams
    {
        public Filter Filter { get; set; }

        public int PageOffset { get; set; }

        public int PageLimit { get; set; }

        public string SortField { get; set; }

        public SortDirection? SortDirection { get; set; }
    }
}