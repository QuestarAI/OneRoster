namespace Questar.OneRoster.Data.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Collections;

    public class OrderedDynamicQuery<T> : DynamicQuery<T>, IOrderedDynamicQuery
    {
        public OrderedDynamicQuery(IQueryable<T> source, IEnumerable<string> fields) : base(source, fields)
        {
        }

        public IPage<dynamic> ToPage(int offset, int limit)
        {
            var count = Source.Count();
            var items = Source.Skip(offset).Take(limit).DynamicSelect(Members).ToList();

            return new Page<dynamic>(offset / limit, limit, count, items);
        }

        public async Task<IPage<dynamic>> ToPageAsync(int offset, int limit)
        {
            var count = Source.Count();
            var items = Source.Skip(offset).Take(limit).DynamicSelect(Members).ToAsyncEnumerable().ToList();

            return new Page<dynamic>(offset / limit, limit, count, await items);
        }

        IPage IOrderedQuery.ToPage(int offset, int limit) => ToPage(offset, limit);

        async Task<IPage> IOrderedQuery.ToPageAsync(int offset, int limit) => await ToPageAsync(offset, limit);
    }
}