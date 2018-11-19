namespace Questar.OneRoster.Filtering.Expressions
{
    using System;

    public class FilterBuilder
    {
        public Filter Value { get; set; }

        public void AndAlso(Filter left, Filter right)
        {
            Value = new LogicalFilter(left, Logical.And, right);
        }

        public void Equal(FilterProperty property, FilterValue value)
        {
            Value = new PredicateFilter(property, Predicate.Equal, value);
        }

        public void GreaterThan(FilterProperty property, FilterValue value)
        {
            Value = new PredicateFilter(property, Predicate.GreaterThan, value);
        }

        public void GreaterThanOrEqual(FilterProperty property, FilterValue value)
        {
            Value = new PredicateFilter(property, Predicate.GreaterThanOrEqual, value);
        }

        public void LessThan(FilterProperty property, FilterValue value)
        {
            Value = new PredicateFilter(property, Predicate.LessThan, value);
        }

        public void LessThanOrEqual(FilterProperty property, FilterValue value)
        {
            Value = new PredicateFilter(property, Predicate.LessThanOrEqual, value);
        }

        public void NotEqual(FilterProperty property, FilterValue value)
        {
            Value = new PredicateFilter(property, Predicate.NotEqual, value);
        }

        public void OrElse(Filter left, Filter right)
        {
            Value = new LogicalFilter(left, Logical.Or, right);
        }

        public void Any(FilterProperty property, FilterValue value)
        {
            Value = new PredicateFilter(property, Predicate.Contains, value);
        }

        public void All(FilterProperty property, FilterValue value)
        {
            Value = new PredicateFilter(property, Predicate.Equal, value);
        }
    }
}