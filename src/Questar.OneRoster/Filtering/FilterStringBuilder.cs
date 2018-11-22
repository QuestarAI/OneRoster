namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;

    public sealed class FilterStringBuilder : FilterVisitor
    {
        private readonly StringBuilder _filter = new StringBuilder();

        public void AndAlso(Filter left, Filter right)
            => _filter.Append($"{left} AND {right}");

        public void All(FilterProperty property, FilterValue value)
            => _filter.Append($"{property}={value}");

        public void Any(FilterProperty property, FilterValue value)
            => _filter.Append($"{property}~{value}");

        public void Equal(FilterProperty left, FilterValue value)
            => _filter.Append($"{left}={value}");

        public void GreaterThan(FilterProperty property, FilterValue value)
            => _filter.Append($"{property}>{value}");

        public void GreaterThanOrEqual(FilterProperty property, FilterValue value)
            => _filter.Append($"{property}>={value}");

        public void LessThan(FilterProperty property, FilterValue value)
            => _filter.Append($"{property}<{value}");

        public void LessThanOrEqual(FilterProperty property, FilterValue value)
            => _filter.Append($"{property}<={value}");

        public void NotEqual(FilterProperty property, FilterValue value)
            => _filter.Append($"{property}!={value}");

        public void OrElse(Filter left, Filter right)
            => _filter.Append($"{left} OR {right}");

        public FilterString ToFilterString()
            => new FilterString(_filter.ToString());

        public override void Visit(LogicalFilter filter)
        {
            Action<Filter, Filter> build;

            switch (filter.Logical)
            {
                case "AND":
                    build = AndAlso;
                    break;
                case "OR":
                    build = OrElse;
                    break;
                default:
                    throw new NotSupportedException($"Logical operator '{filter.Logical}' not supported.");
            }

            build(filter.Left, filter.Right);
        }

        public override void Visit(PredicateFilter filter)
        {
            Action<FilterProperty, FilterValue> build;

            switch (filter.Predicate)
            {
                case "=":
                    build = Equal;
                    break;
                case "<":
                    build = LessThan;
                    break;
                case "<=":
                    build = LessThanOrEqual;
                    break;
                case ">":
                    build = GreaterThan;
                    break;
                case ">=":
                    build = GreaterThanOrEqual;
                    break;
                case "!=":
                    build = NotEqual;
                    break;
                default:
                    throw new NotSupportedException($"Logical operator '{filter.Predicate}' not supported.");
            }

            build(filter.Property, filter.Value);
        }
    }
}