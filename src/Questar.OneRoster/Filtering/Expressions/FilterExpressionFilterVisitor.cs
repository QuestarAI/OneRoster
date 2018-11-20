namespace Questar.OneRoster.Filtering.Expressions
{
    using System;

    public class FilterExpressionFilterVisitor : FilterVisitor
    {
        public FilterExpressionFilterVisitor(FilterExpressionBuilder builder)
        => Builder = builder;

        public FilterExpressionBuilder Builder { get; }

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
                    throw new NotSupportedException($"Logical operator not supported: {filter.Logical}.");
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
                    throw new NotSupportedException($"Predicate operator not supported: {filter.Predicate}.");
            }

            build(filter.Property, filter.Value);
        }
    }
}