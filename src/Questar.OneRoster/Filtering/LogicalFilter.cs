using System.Collections.Generic;
using System.Linq;

namespace Questar.OneRoster.Filtering
{
    public sealed class LogicalFilter : Filter
    {
        public LogicalFilter(Filter left, LogicalOperator logical, Filter right)
        {
            Left = left;
            Logical = logical;
            Right = right;
        }

        public Filter Left { get; }

        public LogicalOperator Logical { get; }

        public Filter Right { get; }

        public override IEnumerable<FilterProperty> GetProperties()
        {
            return Left.GetProperties().Concat(Right.GetProperties());
        }

        public override void Accept(FilterVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}