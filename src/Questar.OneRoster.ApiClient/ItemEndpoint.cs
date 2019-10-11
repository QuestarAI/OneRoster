using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Questar.OneRoster.Payloads;
using Questar.OneRoster.Serialization;

namespace Questar.OneRoster.ApiClient
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Flurl.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Payloads;
    using Serialization;

    public class ItemEndpoint<T> : Endpoint, IItemEndpoint<T>
    {
        public ItemEndpoint(IFlurlClient http, string path)
            : base(http, path)
        {
        }

        public IItemQuery<T, TResult> Fields<TResult>(Expression<Func<T, TResult>> selector)
        {
            return Fields<T, TResult>(selector);
        }

        public Task<T> SingleAsync()
        {
            return SingleAsync<T>();
        }

        protected IItemQuery<T, TContext> Append<TContext>(string key, string value)
        {
            Params[key] = value;
            return this as IItemQuery<T, TContext> ?? new ItemQueryAdapter<TContext>(this);
        }

        protected IItemQuery<T, TContext> Fields<TSource, TContext>(Expression<Func<TSource, TContext>> selector)
        {
            switch (selector.Body)
            {
                case NewExpression @new:
                    return Append<TContext>("fields", string.Join(",", @new.Members.Select(member => member.Name)));
                default:
                    throw new NotSupportedException($"Expression type ({selector.Body.NodeType}) is not supported.");
            }
        }

        protected async Task<TResult> SingleAsync<TResult>()
        {
            var response = await Http.Request(ToUri()).GetAsync();
            var content = await (response.Content?.ReadAsStringAsync() ?? Task.FromResult<string>(null));
            if (content == null)
                throw new InvalidOperationException("Content is empty.");

            var resolver = new OneRosterContractResolver(typeof(T));
            var settings = new JsonSerializerSettings { ContractResolver = resolver, Converters = { new StringEnumConverter() } };
            var payload = JsonConvert.DeserializeObject<Payload<TResult>>(content, settings);
            var statuses = payload.Statuses;
            if (statuses.Any())
                throw new StatusInfoException(statuses);

            return payload.Value;
        }

        private class ItemQueryAdapter<TContext> : IItemQuery<T, TContext>
        {
            private readonly ItemEndpoint<T> _endpoint;

            public ItemQueryAdapter(ItemEndpoint<T> endpoint)
            {
                _endpoint = endpoint;
            }

            public IItemQuery<T, TResult> Fields<TResult>(Expression<Func<TContext, TResult>> selector)
            {
                return _endpoint.Fields(selector);
            }

            public Task<TContext> SingleAsync()
            {
                return _endpoint.SingleAsync<TContext>();
            }
        }
    }
}