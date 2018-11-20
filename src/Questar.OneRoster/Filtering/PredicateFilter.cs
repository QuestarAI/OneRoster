namespace Questar.OneRoster.Filtering
{
    using System.Collections.Generic;

    public sealed class PredicateFilter : Filter
    {
        public PredicateFilter(FilterProperty property, Predicate predicate, FilterValue value)
        {
            Property = property;
            Predicate = predicate;
            Value = value;
        }

        public FilterProperty Property { get; }

        public Predicate Predicate { get; }

        public FilterValue Value { get; }

        public override IEnumerable<FilterProperty> GetProperties()
        {
            yield return Property;
        }

        public override void Visit(FilterVisitor visitor)
            => visitor.Visit(this);

        public override string ToString()
            => $"{Property}{Predicate}{Value}";
    }
}