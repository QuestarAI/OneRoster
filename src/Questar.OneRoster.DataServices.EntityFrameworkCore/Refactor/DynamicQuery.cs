namespace Questar.OneRoster.Data.Services
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DynamicQuery<T> : IDynamicQuery
    {
        public DynamicQuery(IQueryable<T> source, IEnumerable<string> fields)
        {
            Source = source;
            Members = fields.ToList();
        }

        protected IQueryable<T> Source { get; }

        public IEnumerable<string> Members { get; }

        public dynamic Single() => Source.Single();

        public async Task<dynamic> SingleAsync() => await Task.FromResult(Source.DynamicSelect(Members).Single());

        IList IQuery.ToList() => ToList();

        async Task<IList> IQuery.ToListAsync() => await ToListAsync();

        public List<dynamic> ToList() => Source.DynamicSelect(Members).AsEnumerable().ToList();

        public Task<List<dynamic>> ToListAsync() => Source.DynamicSelect(Members).ToAsyncEnumerable().ToList();
    }
}