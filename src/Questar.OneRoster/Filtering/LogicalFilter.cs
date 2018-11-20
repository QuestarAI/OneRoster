namespace Questar.OneRoster.Filtering
{
    using System.Collections.Generic;
    using System.Linq;

    public sealed class LogicalFilter : Filter
    {
        public LogicalFilter(Filter left, Logical logical, Filter right)
        {
            Left = left;
            Logical = logical;
            Right = right;
        }

        public Filter Left { get; }

        public Logical Logical { get; }

        public Filter Right { get; }

        public override IEnumerable<FilterProperty> GetProperties()
            => Left.GetProperties().Concat(Right.GetProperties());

        public override void Accept(FilterVisitor visitor)
            => visitor.Visit(this);
    }
}