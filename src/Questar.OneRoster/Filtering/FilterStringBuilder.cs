namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Text;

    public sealed class FilterStringBuilder : FilterVisitor
    {
        private readonly StringBuilder _filter = new StringBuilder();

        public void AndAlso(Filter left, Filter right)
            => _filter.Append($"{left} {LogicalOperatorString.And} {right}");

        public void All(FilterProperty property, FilterValue value)
            => _filter.Append($"{property}{PredicateOperatorString.Equal}{value}");

        public void Any(FilterProperty property, FilterValue value)
            => _filter.Append($"{property}{PredicateOperatorString.Contains}{value}");

        public void Equal(FilterProperty left, FilterValue value)
            => _filter.Append($"{left}{PredicateOperatorString.Equal}{value}");

        public void GreaterThan(FilterProperty property, FilterValue value)
            => _filter.Append($"{property}{PredicateOperatorString.GreaterThan}{value}");

        public void GreaterThanOrEqual(FilterProperty property, FilterValue value)
            => _filter.Append($"{property}{PredicateOperatorString.GreaterThanOrEqual}{value}");

        public void LessThan(FilterProperty property, FilterValue value)
            => _filter.Append($"{property}{PredicateOperatorString.LessThan}{value}");

        public void LessThanOrEqual(FilterProperty property, FilterValue value)
            => _filter.Append($"{property}{PredicateOperatorString.LessThanOrEqual}{value}");

        public void NotEqual(FilterProperty property, FilterValue value)
            => _filter.Append($"{property}{PredicateOperatorString.NotEqual}{value}");

        public void OrElse(Filter left, Filter right)
            => _filter.Append($"{left} {LogicalOperatorString.Or} {right}");

        public FilterString ToFilterString()
            => new FilterString(_filter.ToString());

        public override void Visit(LogicalFilter filter)
            => LogicalBuilder(filter)(filter.Left, filter.Right);

        public override void Visit(PredicateFilter filter)
            => PredicateBuilder(filter)(filter.Property, filter.Value);

        private Action<Filter, Filter> LogicalBuilder(LogicalFilter filter)
        {
            switch (filter.Logical)
            {
                case LogicalOperatorString.And:
                    return AndAlso;
                case LogicalOperatorString.Or:
                    return OrElse;
                default: throw new NotSupportedException($"Logical operator '{filter.Logical}' not supported.");
            }
        }

        private Action<FilterProperty, FilterValue> PredicateBuilder(PredicateFilter filter)
        {
            switch (filter.Predicate)
            {
                case PredicateOperatorString.Equal:
                    return Equal;
                case PredicateOperatorString.LessThan:
                    return LessThan;
                case PredicateOperatorString.LessThanOrEqual:
                    return LessThanOrEqual;
                case PredicateOperatorString.GreaterThan:
                    return GreaterThan;
                case PredicateOperatorString.GreaterThanOrEqual:
                    return GreaterThanOrEqual;
                case PredicateOperatorString.NotEqual:
                    return NotEqual;
                default: throw new NotSupportedException($"Logical operator '{filter.Predicate}' not supported.");
            }
        }
    }
}