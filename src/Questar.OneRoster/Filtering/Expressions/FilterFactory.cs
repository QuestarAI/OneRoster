namespace Questar.OneRoster.Filtering.Expressions
{
    using System.Linq.Expressions;

    public class FilterFactory
    {
        public Filter Create<T>(Expression node)
        {
            var builder = new FilterBuilder();
            var visitor = new FilterExpressionVisitor<T>(builder, this);
            visitor.Visit(node);
            return builder.Value;
        }

        public FilterProperty CreateProperty<T>(Expression node)
        {
            var builder = new FilterPropertyBuilder();
            var visitor = new FilterPropertyExpressionVisitor<T>(builder, this);
            visitor.Visit(node);
            return builder.Value;
        }

        public FilterValue CreateValue<T>(Expression node)
        {
            var builder = new FilterValueBuilder();
            var visitor = new FilterValueExpressionVisitor<T>(builder, this);
            visitor.Visit(node);
            return builder.Value;
        }
    }
}