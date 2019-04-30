namespace Questar.OneRoster.Client.Implementations
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Collections;
    using Filtering;
    using Flurl.Http;
    using Newtonsoft.Json;
    using Serialization;
    using Sorting;

    public class ListEndpoint<T> : Endpoint<T>, IListEndpoint<T>
    {
        public ListEndpoint(string host, string path)
            : base(host, path)
        {
        }

        public IListQuery<T, TResult> Fields<TResult>(Expression<Func<T, TResult>> selector)
            => Fields<T, TResult>(selector);

        public IListQuery<T, T> Filter(Expression<Func<T, bool>> predicate)
            => Filter<T>(predicate);

        public IListQuery<T, T> Limit(int limit)
            => Limit<T>(limit);

        public IListQuery<T, T> Offset(int offset)
            => Offset<T>(offset);

        public IListQuery<T, T> Sort(Expression<Func<T, object>> selector)
            => Sort<T>(selector);

        public IListQuery<T, T> OrderBy(SortDirection direction)
            => OrderBy<T>(direction);

        public Task<Page<T>> ToPageAsync()
            => ToPageAsync<T>();

        protected IListQuery<T, TContext> Append<TContext>(string key, string value)
        {
            Query[key] = value;
            return this as IListQuery<T, TContext> ?? new ListQueryAdapter<TContext>(this);
        }

        protected IListQuery<T, TContext> Fields<TSource, TContext>(Expression<Func<TSource, TContext>> selector)
            => Append<TContext>("fields", string.Join(",", ((NewExpression) selector.Body).Members.Select(member => member.Name)));

        protected IListQuery<T, TContext> Filter<TContext>(Expression<Func<T, bool>> predicate)
            => Append<TContext>("filter", new FilterExpression<T>(predicate).ToFilter().ToString());

        protected IListQuery<T, TContext> Limit<TContext>(int value)
            => Append<TContext>("limit", value.ToString());

        protected IListQuery<T, TContext> Offset<TContext>(int value)
            => Append<TContext>("offset", value.ToString());

        protected IListQuery<T, TContext> OrderBy<TContext>(SortDirection direction)
            => Append<TContext>("orderBy", Enum.GetName(typeof(SortDirection), direction));

        protected IListQuery<T, TContext> Sort<TContext>(Expression<Func<T, object>> selector)
            => Append<TContext>("sort", ((MemberExpression) selector.Body).Member.Name);

        public async Task<Page<TResult>> ToPageAsync<TResult>()
        {
            var response = await Http.Request(ToUri()).GetAsync();

            var content = await (response.Content?.ReadAsStringAsync() ?? Task.FromResult<string>(null));
            if (content == null)
                throw new InvalidOperationException("Content is empty.");

            var resolver = new OneRosterContractResolver(typeof(T));
            var settings = new JsonSerializerSettings {ContractResolver = resolver};

            var result = JsonConvert.DeserializeObject<OneRosterCollection<TResult>>(content, settings);
            var statuses = result.StatusInfoSet;
            if (statuses.Any())
                throw new OneRosterException(statuses);

            var total = int.Parse(response.Headers.GetValues("X-Total-Count").Single());
            var value = result.Results;
            return new Page<TResult>(0, 0, total, value);
        }

        private class ListQueryAdapter<TContext> : IListQuery<T, TContext>
        {
            private readonly ListEndpoint<T> _endpoint;

            public ListQueryAdapter(ListEndpoint<T> endpoint)
                => _endpoint = endpoint;

            public IListQuery<T, TResult> Fields<TResult>(Expression<Func<TContext, TResult>> selector)
                => _endpoint.Fields(selector);

            public IListQuery<T, TContext> Filter(Expression<Func<T, bool>> predicate)
                => _endpoint.Filter<TContext>(predicate);

            public IListQuery<T, TContext> Limit(int limit)
                => _endpoint.Limit<TContext>(limit);

            public IListQuery<T, TContext> Offset(int offset)
                => _endpoint.Offset<TContext>(offset);

            public IListQuery<T, TContext> Sort(Expression<Func<T, object>> selector)
                => _endpoint.Sort<TContext>(selector);

            public IListQuery<T, TContext> OrderBy(SortDirection direction)
                => _endpoint.OrderBy<TContext>(direction);

            public Task<Page<TContext>> ToPageAsync()
                => _endpoint.ToPageAsync<TContext>();
        }
    }
}