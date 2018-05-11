namespace Questar.OneRoster.Query.Exceptions
{
    using System;

    public class UnusedFilterException : Exception
    {
        public string Filter { get; }
        public string UnusedFilter { get; }
        public int StartUnused { get; }
        public int EndUnused { get; }

        private UnusedFilterException(string filter, string unusedFilter, int startUnused, int endUnused, string message)
            : base(message)
        {
            Filter = filter;
            UnusedFilter = unusedFilter;
            StartUnused = startUnused;
            EndUnused = endUnused;
        }

        internal static UnusedFilterException FromArgs(string filter, int startUnused, int endUnused)
        {
            var unusedFilter = filter.Substring(startUnused, endUnused - startUnused);
            var message = $"Unused portion of filter string. Unused: {unusedFilter}";
            return new UnusedFilterException(filter, unusedFilter, startUnused, endUnused, message);
        }
    }
}