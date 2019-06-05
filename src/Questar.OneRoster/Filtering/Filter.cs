using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Questar.OneRoster.Filtering
{
    public abstract class Filter
    {
        private static readonly Regex And = new Regex(@"(?<Left>.+)\s+AND\s+(?<Right>.+)", RegexOptions.Compiled);

        private static readonly Regex Or = new Regex(@"(?<Left>.+)\s+OR\s+(?<Right>.+)", RegexOptions.Compiled);

        private static readonly Regex Predicate = new Regex(@"(?<Property>[A-Za-z0-9_\.]+)(?<Predicate>!=|=|>=|>|<=|<|~)(?<Value>.+)", RegexOptions.Compiled);

        internal Filter()
        {
        }

        public abstract void Accept(FilterVisitor visitor);

        public static Filter Parse(string text)
        {
            var or = Or.Match(text);
            if (or.Success)
                return new LogicalFilter
                (
                    Parse(or.Groups["Left"].Value),
                    LogicalOperator.Or,
                    Parse(or.Groups["Right"].Value)
                );
            var and = And.Match(text);
            if (and.Success)
                return new LogicalFilter
                (
                    Parse(and.Groups["Left"].Value),
                    LogicalOperator.And,
                    Parse(and.Groups["Right"].Value)
                );
            var predicate = Predicate.Match(text);
            if (predicate.Success)
                return new PredicateFilter
                (
                    FilterProperty.Parse(predicate.Groups["Property"].Value),
                    PredicateOperator.Parse(predicate.Groups["Predicate"].Value),
                    FilterValue.Parse(predicate.Groups["Value"].Value)
                );
            throw new ArgumentException($"Couldn't parse filter '{text}'.");
        }

        public abstract IEnumerable<FilterProperty> GetProperties();

        public FilterExpression<T> ToFilterExpression<T>()
        {
            var builder = new FilterExpressionBuilder<T>();
            Accept(builder);
            return builder.ToFilterExpression();
        }

        public FilterString ToFilterString()
        {
            var builder = new FilterStringBuilder();
            Accept(builder);
            return builder.ToFilterString();
        }

        public override string ToString()
        {
            return ToFilterString();
        }
    }
}