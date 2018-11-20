namespace Questar.OneRoster.Filtering
{
    using System;

    public class FilterStringFilterVisitor : FilterVisitor
    {
        public FilterStringBuilder Builder { get; }

        public FilterStringFilterVisitor(FilterStringBuilder builder) => Builder = builder;

        public override void Visit(LogicalFilter filter)
        {
            Action<Filter, Filter> build;

            switch (filter.Logical)
            {
                case "AND":
                    build = Builder.AndAlso;
                    break;
                case "OR":
                    build = Builder.OrElse;
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
                    build = Builder.Equal;
                    break;
                case ">":
                    build = Builder.LessThan;
                    break;
                case ">=":
                    build = Builder.LessThanOrEqual;
                    break;
                case "<":
                    build = Builder.GreaterThan;
                    break;
                case "<=":
                    build = Builder.GreaterThanOrEqual;
                    break;
                case "!=":
                    build = Builder.NotEqual;
                    break;
                default:
                    throw new NotSupportedException($"Logical operator '{filter.Predicate}' not supported.");
            }

            build(filter.Property, filter.Value);
        }
    }
}