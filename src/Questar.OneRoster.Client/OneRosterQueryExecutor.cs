namespace Questar.OneRoster.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Flurl.Http;
    using Newtonsoft.Json;
    using Remotion.Linq;

    public class OneRosterQueryExecutor : IQueryExecutor
    {
        private readonly IFlurlClient _http;
        private readonly string _path;

        public OneRosterQueryExecutor(IFlurlClient http, string path)
        {
            _http = http;
            _path = path;
        }

        public T ExecuteScalar<T>(QueryModel model)
            => throw new NotSupportedException("Querying a scalar value is not supported by the OneRoster® specification.");

        public T ExecuteSingle<T>(QueryModel model, bool returnDefaultWhenEmpty)
            => Task.Run(() => ExecuteSingleAsync<T>(model, returnDefaultWhenEmpty)).GetAwaiter().GetResult();

        public IEnumerable<T> ExecuteCollection<T>(QueryModel model)
            => Task.Run(() => ExecuteCollectionAsync<T>(model)).GetAwaiter().GetResult();

        public async Task<T> ExecuteSingleAsync<T>(QueryModel model, bool returnDefaultWhenEmpty)
        {
            var response =
                await _http
                    .Request(_path)
                    .GetAsync();

            var content = await (response.Content?.ReadAsStringAsync() ?? Task.FromResult<string>(null));
            if (content == null)
                throw new InvalidOperationException("Content is empty.");

            var resolver = new OneRosterContractResolver(model.MainFromClause.ItemType);
            var settings = new JsonSerializerSettings {ContractResolver = resolver};

            var result = JsonConvert.DeserializeObject<OneRosterSingle<T>>(content, settings);
            var statuses = result.StatusInfoSet;
            if (statuses.Any())
                throw new OneRosterException(statuses);

            var value = result.Result;
            if (value != null)
                return value;

            if (returnDefaultWhenEmpty)
                return default;

            throw new InvalidOperationException("The source sequence is empty.");
        }

        public async Task<IEnumerable<T>> ExecuteCollectionAsync<T>(QueryModel model)
        {
            var response =
                await _http
                    .Request(_path)
                    .GetAsync();

            var content = await (response.Content?.ReadAsStringAsync() ?? Task.FromResult<string>(null));
            if (content == null)
                throw new InvalidOperationException("Content is empty.");

            var resolver = new OneRosterContractResolver(model.MainFromClause.ItemType);
            var settings = new JsonSerializerSettings {ContractResolver = resolver};

            var result = JsonConvert.DeserializeObject<OneRosterCollection<T>>(content, settings);
            var statuses = result.StatusInfoSet;
            if (statuses.Any())
                throw new OneRosterException(statuses);

            var total = int.Parse(response.Headers.GetValues("X-Total-Count").Single());

            return new OneRosterQueryResult<T>(result.Results, total, statuses);
        }
    }
}