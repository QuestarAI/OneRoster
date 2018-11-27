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
        {
            Action<Filter, Filter> build;

            switch (filter.Logical)
            {
                case LogicalOperatorString.And:
                    build = AndAlso;
                    break;
                case LogicalOperatorString.Or:
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
                case PredicateOperatorString.Equal:
                    build = Equal;
                    break;
                case PredicateOperatorString.LessThan:
                    build = LessThan;
                    break;
                case PredicateOperatorString.LessThanOrEqual:
                    build = LessThanOrEqual;
                    break;
                case PredicateOperatorString.GreaterThan:
                    build = GreaterThan;
                    break;
                case PredicateOperatorString.GreaterThanOrEqual:
                    build = GreaterThanOrEqual;
                    break;
                case PredicateOperatorString.NotEqual:
                    build = NotEqual;
                    break;
                default:
                    throw new NotSupportedException($"Logical operator '{filter.Predicate}' not supported.");
            }

            build(filter.Property, filter.Value);
        }
    }
}