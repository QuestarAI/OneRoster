namespace Questar.OneRoster.Filtering
{
    public abstract class FilterVisitor
    {
        public abstract void Visit(LogicalFilter filter);

        public abstract void Visit(PredicateFilter filter);
    }
}