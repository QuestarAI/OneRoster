namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Collections;
    using OneRoster.Collections;

    public class OrderedQuery<T> : Query<T>, IOrderedQuery<T>
    {
        public OrderedQuery(IOrderedQueryable<T> source, Func<T, object> keySelector, Func<object, object, bool> keyComparer) : base(source, keySelector, keyComparer)
        {
        }

        protected new IOrderedQueryable<T> Source => (IOrderedQueryable<T>) base.Source;

        public new IOrderedDynamicQuery Fields(IEnumerable<string> fields) => (IOrderedDynamicQuery) base.Fields(fields);

        IPage<T> IOrderedQuery<T>.ToPage(int offset, int limit) => ToPage(offset, limit);

        async Task<IPage<T>> IOrderedQuery<T>.ToPageAsync(int offset, int limit) => await ToPageAsync(offset, limit);

        IPage IOrderedQuery.ToPage(int offset, int limit) => ToPage(offset, limit);

        async Task<IPage> IOrderedQuery.ToPageAsync(int offset, int limit) => await ToPageAsync(offset, limit);

        protected override IDynamicQuery ToDynamic(IEnumerable<string> fields) => new OrderedDynamicQuery<T>(Source, fields);

        public Page<T> ToPage(int offset, int limit) => Source.ToPage(offset, limit);

        public Task<Page<T>> ToPageAsync(int offset, int limit) => Source.ToPageAsync(offset, limit);
    }
}