namespace Questar.OneRoster.Query
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text.RegularExpressions;

    public class FilterParser
    {
        private const RegexOptions CompiledIgnoreCase = RegexOptions.Compiled | RegexOptions.IgnoreCase;
        private const string FieldNameRegex = @"(?<FieldName>[A-Z0-9:_]+(?:\.[A-Z0-9:_]+)*)";
        private const string OperatorRegex = @"(?:\s*(?<Operator>=|!=|>|>=|<|<=|~)\s*)";
        private const string ValueRegex = @"(?:'(?<SingleQuotedValue>[^']+)'|""(?<DoubleQuotedValue>[^""]+)"")";
        private const string LogicalRegex = @"(?:^|(?<!^)\s+(?<AndOr>AND|OR)\s+)";
        private const string FilterRegexPattern = ""
            + LogicalRegex
            + FieldNameRegex
            + OperatorRegex
            + ValueRegex;

        private static readonly Regex FilterRegex = new Regex(FilterRegexPattern, CompiledIgnoreCase);

        public static IList<Filter> FromString(string filter)
        {
            var filters = new List<Filter>();
            if (filter == null) return filters;

            var trimmedFilter = filter.Trim();
            if (trimmedFilter == "") return filters;

            var start = 0;
            var matches = FilterRegex.Matches(trimmedFilter);
            foreach (Match match in matches)
            {
                if (match.Index == start)
                {
                    start = match.Index + match.Length;
                }
                else
                {
                    throw UnusedFilterException.FromArgs(trimmedFilter, start, match.Index);
                }

                var groups = match.Groups;
                var andOr = groups["AndOr"];
                var single = groups["SingleQuotedValue"];

                filters.Add(new Filter
                {
                    AndOr = andOr.Success ? (Logical?)Enum.Parse(typeof(Logical), andOr.Value, true) : null,
                    FieldName = groups["FieldName"].Value,
                    Operator = groups["Operator"].Value,
                    Value = single.Success ? single.Value : groups["DoubleQuotedValue"].Value,
                });
            }

            if (start != trimmedFilter.Length)
            {
                throw UnusedFilterException.FromArgs(trimmedFilter, start, trimmedFilter.Length);
            }

            return filters;
        }

    }

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

        public static UnusedFilterException FromArgs(string filter, int startUnused, int endUnused)
        {
            var unusedFilter = filter.Substring(startUnused, endUnused - startUnused);
            var message = $"Unused portion of filter string. Unused: {unusedFilter}";
            return new UnusedFilterException(filter, unusedFilter, startUnused, endUnused, message);
        }
    }
}