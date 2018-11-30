namespace Questar.OneRoster.Filtering
{
    using System.Collections.Generic;

    public sealed class PredicateFilter : Filter
    {
        public PredicateFilter(FilterProperty property, PredicateOperator predicate, FilterValue value)
        {
            Property = property;
            Predicate = predicate;
            Value = value;
        }

        public FilterProperty Property { get; }

        public PredicateOperator Predicate { get; }

        public FilterValue Value { get; }

        public override IEnumerable<FilterProperty> GetProperties()
        {
            yield return Property;
        }

        public override void Accept(FilterVisitor visitor)
            => visitor.Visit(this);

        public override string ToString()
            => $"{Property}{Predicate}{Value}";
    }
}