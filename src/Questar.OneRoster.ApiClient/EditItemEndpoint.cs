using System;
using System.Threading.Tasks;
using Flurl.Http;

namespace Questar.OneRoster.ApiClient
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Flurl.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Serialization;

    public class EditItemEndpoint<T> : ItemEndpoint<T>, IEditItemEndpoint<T>
    {
        public EditItemEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public Task UpsertAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var resolver = new OneRosterContractResolver(typeof(T));
            var settings = new JsonSerializerSettings { ContractResolver = resolver, Converters = { new StringEnumConverter() } };
            var content = new StringContent(JsonConvert.SerializeObject(entity, settings), Encoding.UTF8, "application/json");

            return Http.Request(ToUri()).SendAsync(HttpMethod.Put, content);
        }

        public Task DeleteAsync() =>
            Http.Request(ToUri()).SendAsync(HttpMethod.Delete);
    }
}