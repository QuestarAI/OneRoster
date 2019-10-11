using System.Collections.Generic;
using System.Linq;
using Flurl.Http;

namespace Questar.OneRoster.ApiClient
{
    using System.Collections.Generic;
    using System.Linq;
    using Flurl.Http;

    public abstract class Endpoint
    {
        protected readonly IDictionary<string, string> Params = new Dictionary<string, string>();

        protected Endpoint(IFlurlClient http, string path)
        {
            Http = http;
            Path = path;
        }

        public IFlurlClient Http { get; }

        public string Path { get; set; }

        public string ToUri() =>
            $"{Path}?{string.Join("&", Params.Select(entry => $"{entry.Key}={entry.Value}"))}";
    }
}