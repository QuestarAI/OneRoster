namespace Questar.OneRoster.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Remotion.Linq;

    public class OneRosterQueryable<TElement> : QueryableBase<TElement>, IOneRosterQueryResultProvider<TElement>
    {
        public OneRosterQueryable(IQueryProvider provider)
            : base(provider)
        {
        }

        public OneRosterQueryable(IQueryProvider provider, Expression expression)
            : base(provider, expression)
        {
        }

        OneRosterQueryResult<TElement> IOneRosterQueryResultProvider<TElement>.GetQueryResult()
            => (OneRosterQueryResult<TElement>) Provider.Execute(Expression);
    }
}