namespace Questar.OneRoster.Client.Implementations
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Flurl.Http;
    using Newtonsoft.Json;
    using Serialization;

    public class ItemEndpoint<T> : Endpoint<T>, IItemEndpoint<T>
    {
        public ItemEndpoint(string path)
            : base(path)
        {
        }

        public IItemQuery<T, TResult> Fields<TResult>(Expression<Func<T, TResult>> selector)
            => Fields<T, TResult>(selector);

        public Task<T> SingleAsync()
            => SingleAsync<T>();

        protected IItemQuery<T, TContext> Append<TContext>(string key, string value)
        {
            Query[key] = value;
            return this as IItemQuery<T, TContext> ?? new ItemQueryAdapter<TContext>(this);
        }

        protected IItemQuery<T, TContext> Fields<TSource, TContext>(Expression<Func<TSource, TContext>> selector)
            => Append<TContext>("fields", string.Join(",", ((NewExpression) selector.Body).Members.Select(member => member.Name)));

        protected async Task<TResult> SingleAsync<TResult>()
        {
            var response = await Http.Request(ToUri()).GetAsync();

            var content = await (response.Content?.ReadAsStringAsync() ?? Task.FromResult<string>(null));
            if (content == null)
                throw new InvalidOperationException("Content is empty.");

            var resolver = new OneRosterContractResolver(typeof(T));
            var settings = new JsonSerializerSettings {ContractResolver = resolver};

            var result = JsonConvert.DeserializeObject<OneRosterSingle<TResult>>(content, settings);
            var statuses = result.StatusInfoSet;
            if (statuses.Any())
                throw new OneRosterException(statuses);

            var value = result.Result;
            return value;
        }

        private class ItemQueryAdapter<TContext> : IItemQuery<T, TContext>
        {
            private readonly ItemEndpoint<T> _endpoint;

            public ItemQueryAdapter(ItemEndpoint<T> endpoint)
                => _endpoint = endpoint;

            public IItemQuery<T, TResult> Fields<TResult>(Expression<Func<TContext, TResult>> selector)
                => _endpoint.Fields(selector);

            public Task<TContext> SingleAsync()
                => _endpoint.SingleAsync<TContext>();
        }
    }
}