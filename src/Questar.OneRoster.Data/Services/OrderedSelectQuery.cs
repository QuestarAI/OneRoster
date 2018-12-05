namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using OneRoster.Collections;

    public class OrderedSelectQuery<T> : SelectQuery<T>, IOrderedSelectQuery<T>
    {
        public OrderedSelectQuery(SelectQuery<T> source) : base(source.Source)
        {
        }

        public new IOrderedSelectQuery Fields(IEnumerable<string> fields) => (IOrderedSelectQuery) base.Fields(fields);

        public IPage<T> ToPage(int offset, int limit) => throw new NotImplementedException();

        public Task<IPage<T>> ToPageAsync(int offset, int limit) => throw new NotImplementedException();

        IPage IOrderedSelectQuery.ToPage(int offset, int limit) => ToPage(offset, limit);

        Task<IPage> IOrderedSelectQuery.ToPageAsync(int offset, int limit) => throw new NotImplementedException();
    }
}