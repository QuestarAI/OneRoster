namespace Questar.OneRoster.Filtering
{
    using System;

    public class FilterStringFilterVisitor : FilterVisitor
    {
        public FilterStringBuilder Builder { get; }

        public FilterStringFactory Factory { get; }

        public FilterStringFilterVisitor(FilterStringBuilder builder, FilterStringFactory factory)
        {
            Builder = builder;
            Factory = factory;
        }

        public override void Visit(LogicalFilter filter)
        {
            Action<FilterString, FilterString> build;

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

            build(Factory.Create(filter.Left), Factory.Create(filter.Right));
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