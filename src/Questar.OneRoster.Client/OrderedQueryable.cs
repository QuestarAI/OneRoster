namespace Questar.OneRoster.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class OrderedQueryable<TElement> : IOrderedQueryable<TElement>
    {
        public OrderedQueryable()
        {
            Provider = new QueryProvider<TElement>();
            Expression = Expression.Constant(this);
        }

        public Type ElementType => typeof(TElement);

        public Expression Expression { get; }

        public IQueryProvider Provider { get; }

        public IEnumerator<TElement> GetEnumerator() => Provider.Execute<IEnumerable<TElement>>(Expression).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}