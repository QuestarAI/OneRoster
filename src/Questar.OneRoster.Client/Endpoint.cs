namespace Questar.OneRoster.Client
{
    using System.Collections.Generic;
    using System.Linq;
    using Flurl.Http;

    public abstract class Endpoint<T>
    {
        protected readonly IDictionary<string, string> Query = new Dictionary<string, string>();

        protected Endpoint(IFlurlClient http, string path)
        {
            Http = http;
            Path = path;
        }

        public IFlurlClient Http { get; }

        public string Path { get; set; }

        public string ToUri()
        {
            return $"{Path}?{string.Join("&", Query.Select(entry => $"{entry.Key}={entry.Value}"))}";
        }
    }
}