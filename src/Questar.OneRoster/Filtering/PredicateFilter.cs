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
            var property = Property;
            do
            {
                yield return property;
                property = property.Caller;
            } while (property != null);
        }

        public override void Visit(FilterVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}