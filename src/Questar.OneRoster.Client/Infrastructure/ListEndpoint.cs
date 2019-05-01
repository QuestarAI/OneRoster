namespace Questar.OneRoster.Client.Infrastructure
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Collections;
    using Filtering;
    using Flurl.Http;
    using Models;
    using Newtonsoft.Json;
    using Serialization;
    using Sorting;

    public class ListEndpoint<T> : Endpoint<T>, IListEndpoint<T>
    {
        public ListEndpoint(IFlurlClient http, string path)
            : base(http, path)
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

        public IListQuery<T, T> Sort<TResult>(Expression<Func<T, TResult>> selector)
            => Sort<T, TResult>(selector);

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
        {
            switch (selector.Body)
            {
                case NewExpression @new:
                    return Append<TContext>("fields", string.Join(",", @new.Members.Select(member => member.Name)));
                default:
                    throw new NotSupportedException($"Expression type ({selector.Body.NodeType}) is not supported.");
            }
        }

        protected IListQuery<T, TContext> Filter<TContext>(FilterExpression<T> predicate)
            => Append<TContext>("filter", predicate.ToFilter().ToString());

        protected IListQuery<T, TContext> Limit<TContext>(int value)
            => Append<TContext>("limit", value.ToString());

        protected IListQuery<T, TContext> Offset<TContext>(int value)
            => Append<TContext>("offset", value.ToString());

        protected IListQuery<T, TContext> OrderBy<TContext>(SortDirection direction)
            => Append<TContext>("orderBy", Enum.GetName(typeof(SortDirection), direction));

        protected IListQuery<T, TContext> Sort<TContext, TResult>(Expression<Func<T, TResult>> selector)
        {
            switch (selector.Body)
            {
                case MemberExpression member:
                    return Append<TContext>("sort", member.Member.Name);
                default:
                    throw new NotSupportedException($"Expression type ({selector.Body.NodeType}) is not supported.");
            }
        }

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
            return new Page<TResult>(total, value);
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

            public IListQuery<T, TContext> Sort<TResult>(Expression<Func<T, TResult>> selector)
                => _endpoint.Sort<TContext, TResult>(selector);

            public IListQuery<T, TContext> OrderBy(SortDirection direction)
                => _endpoint.OrderBy<TContext>(direction);

            public Task<Page<TContext>> ToPageAsync()
                => _endpoint.ToPageAsync<TContext>();
        }
    }
}