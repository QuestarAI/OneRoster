namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SingleQueryBuilder<T> : QueryBuilder, ISingleQueryBuilder<T> where T : Base
    {
        public SingleQueryBuilder(IQueryable<T> source) => Source = source;

        public IQueryable<T> Source { get; }

        public T Query(Guid sourcedId)
            => Source.SingleOrDefault(source => source.SourcedId == sourcedId);

        public Task<T> QueryAsync(Guid sourcedId)
            => Source.SingleOrDefaultAsync(source => source.SourcedId == sourcedId);

        object ISingleQueryBuilder.Query(Guid sourcedId) => Query(sourcedId);

        async Task<object> ISingleQueryBuilder.QueryAsync(Guid sourcedId) => await QueryAsync(sourcedId);

        public new ISingleQueryBuilder Fields(string[] fields) => (ISingleQueryBuilder)base.Fields(fields);
    }
}