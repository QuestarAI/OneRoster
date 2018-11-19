namespace Questar.OneRoster.Filtering.Expressions
{
    using System;
    using System.Linq.Expressions;

    public class FilterExpressionFilterVisitor<T> : FilterVisitor
    {
        public FilterExpressionFilterVisitor(FilterExpressionBuilder<T> builder, FilterExpressionFactory<T> factory)
        {
            Builder = builder;
            Factory = factory;
        }

        public FilterExpressionBuilder<T> Builder { get; }

        public FilterExpressionFactory<T> Factory { get; }

        public override void Visit(LogicalFilter filter)
        {
            Action<FilterExpression<T>, FilterExpression<T>> build;

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

            build(Factory.Create(filter.Left), Factory.Create(filter.Right));
        }

        public override void Visit(PredicateFilter filter)
        {
            // TODO FilterPropertyExpression
            // TODO FilterValueExpression

            Action<Expression, ConstantExpression> build;

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

            build(Factory.CreateProperty(filter.Property), Factory.CreateValue(filter.Value));
        }
    }
}