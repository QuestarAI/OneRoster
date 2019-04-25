namespace Questar.OneRoster.Client
{
    using System.Linq;
    using System.Linq.Expressions;
    using Remotion.Linq;
    using Remotion.Linq.Parsing.Structure;

    public class OneRosterQueryProvider : QueryProviderBase
    {
        public OneRosterQueryProvider(IQueryParser queryParser, IQueryExecutor executor) : base(queryParser, executor)
        {
        }

        public override IQueryable<T> CreateQuery<T>(Expression expression) => new OneRosterQueryable<T>(this, expression);
    }
}