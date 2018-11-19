namespace Questar.OneRoster.Filtering
{
    public class FilterStringFactory
    {
        public FilterString Create(Filter filter)
        {
            var builder = new FilterStringBuilder();
            var visitor = new FilterStringFilterVisitor(builder, this);
            filter.Visit(visitor);
            return builder.ToFilterString();
        }
    }
}