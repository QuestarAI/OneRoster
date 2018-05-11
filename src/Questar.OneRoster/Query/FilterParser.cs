namespace Questar.OneRoster.Query
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Exceptions;

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
                    AndOr = andOr.Success ? (LogicalOperator?)Enum.Parse(typeof(LogicalOperator), andOr.Value, true) : null,
                    FieldName = groups["FieldName"].Value,
                    Operator = ParseBinaryOperator(groups["Operator"].Value),
                    Value = single.Success ? single.Value : groups["DoubleQuotedValue"].Value,
                });
            }

            if (start != trimmedFilter.Length)
            {
                throw UnusedFilterException.FromArgs(trimmedFilter, start, trimmedFilter.Length);
            }

            return filters;
        }

        private static BinaryOperator ParseBinaryOperator(string op)
        {
            switch (op)
            {
                case "=": return BinaryOperator.Equal;
                case "!=": return BinaryOperator.NotEqual;
                case ">": return BinaryOperator.GreaterThan;
                case ">=": return BinaryOperator.GreaterThanOrEqual;
                case "<": return BinaryOperator.LessThan;
                case "<=": return BinaryOperator.LessThanOrEqual;
                case "~": return BinaryOperator.Contains;
                default: throw new InvalidOperationException($"Could not parse binary operator {op}.");
            }
        }
    }
}