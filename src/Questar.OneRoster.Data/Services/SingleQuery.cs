namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SingleQuery<T> : Query, ISingleQuery<T> where T : Base // TODO Base...
    {
        public SingleQuery(IQueryable<T> source) => Source = source;

        public IQueryable<T> Source { get; }

        public T ToObject(Guid id)
            => Source.SingleOrDefault(source => source.SourcedId == id);

        public Task<T> ToObjectAsync(Guid id)
            => Source.SingleOrDefaultAsync(source => source.SourcedId == id);

        object ISingleQuery.ToObject(Guid sourcedId) => ToObject(sourcedId);

        async Task<object> ISingleQuery.ToObjectAsync(Guid sourcedId) => await ToObjectAsync(sourcedId);

        public new ISingleQuery Fields(IEnumerable<string> fields) => (ISingleQuery)base.Fields(fields);
    }
}