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

        public IPage ToPage(int offset, int limit)
        {
            var count = Source.Count();
            var items = Invoke(Source.Skip(offset).Take(limit)).AsEnumerable().Select(Map).ToList();

            return new Page<dynamic>(offset / limit, limit, count, items);
        }

        public async Task<IPage> ToPageAsync(int offset, int limit)
        {
            var count = Source.Count();
            var items = Invoke(Source.Skip(offset).Take(limit)).AsEnumerable().Select(Map).ToList();

            // TODO async enumerable is not supported by the provider

            return await Task.FromResult(new Page<dynamic>(offset / limit, limit, count, items));
        }
    }
}