namespace Questar.OneRoster.Filtering.Expressions
{
    using System.Collections.Generic;

    public class FilterBuilder
    {
        private readonly Stack<Filter> _filters = new Stack<Filter>();

        public Filter Value { get; set; }

        public FilterBuilder AndAlso(Filter left, Filter right)
        {
            _filters.Push(new LogicalFilter(left, Logical.And, right));
            return this;
        }

        public FilterBuilder Any(FilterProperty property, FilterValue value)
        {
            _filters.Push(new PredicateFilter(property, Predicate.Contains, value));
            return this;
        }

        public FilterBuilder All(FilterProperty property, FilterValue value)
        {
            _filters.Push(new PredicateFilter(property, Predicate.Equal, value));
            return this;
        }

        public FilterBuilder Equal(FilterProperty property, FilterValue value)
        {
            _filters.Push(new PredicateFilter(property, Predicate.Equal, value));
            return this;
        }

        public FilterBuilder GreaterThan(FilterProperty property, FilterValue value)
        {
            _filters.Push(new PredicateFilter(property, Predicate.GreaterThan, value));
            return this;
        }

        public FilterBuilder GreaterThanOrEqual(FilterProperty property, FilterValue value)
        {
            _filters.Push(new PredicateFilter(property, Predicate.GreaterThanOrEqual, value));
            return this;
        }

        public FilterBuilder LessThan(FilterProperty property, FilterValue value)
        {
            _filters.Push(new PredicateFilter(property, Predicate.LessThan, value));
            return this;
        }

        public FilterBuilder LessThanOrEqual(FilterProperty property, FilterValue value)
        {
            _filters.Push(new PredicateFilter(property, Predicate.LessThanOrEqual, value));
            return this;
        }

        public FilterBuilder NotEqual(FilterProperty property, FilterValue value)
        {
            _filters.Push(new PredicateFilter(property, Predicate.NotEqual, value));
            return this;
        }

        public FilterBuilder OrElse(Filter left, Filter right)
        {
            _filters.Push(new LogicalFilter(left, Logical.Or, right));
            return this;
        }

        public Filter Peek()
            => _filters.Peek();

        public Filter Pop()
            => _filters.Pop();
    }
}