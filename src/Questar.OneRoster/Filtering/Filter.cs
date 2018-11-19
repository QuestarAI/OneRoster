namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public abstract class Filter
    {
        private static readonly Regex PredicateRegex = new Regex(@"(?<Property>[A-Za-z0-9_\.]+)(?<Predicate>!=|=|>=|>|<=|<|~)(?<Value>.+)", RegexOptions.Compiled);

        private static readonly Regex LogicalRegex = new Regex(@"(?<Left>.+)\s+(?<Logical>AND|OR)\s+(?<Right>.+)", RegexOptions.Compiled);

        public static Filter Parse(string text)
        {
            var logical = LogicalRegex.Match(text);
            if (logical.Success)
                return new LogicalFilter
                (
                    Parse(logical.Groups["Left"].Value),
                    Logical.Parse(logical.Groups["Logical"].Value),
                    Parse(logical.Groups["Right"].Value)
                );
            var predicate = PredicateRegex.Match(text);
            if (predicate.Success)
                return new PredicateFilter
                (
                    FilterProperty.Parse(logical.Groups["Property"].Value),
                    Predicate.Parse(logical.Groups["Predicate"].Value),
                    FilterValue.Parse(logical.Groups["Value"].Value)
                );
            throw new ArgumentException($"Couldn't parse filter '{text}'.");
        }

        public abstract IEnumerable<FilterProperty> GetProperties();

        public abstract void Visit(FilterVisitor visitor);

        public FilterString ToFilterString()
        {
            return new FilterStringFactory().Create(this);
        }

        public override string ToString()
        {
            return ToFilterString();
        }
    }
}