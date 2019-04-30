namespace Questar.OneRoster.Client.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Flurl.Http;

    public abstract class Endpoint<T>
    {
        protected readonly IDictionary<string, string> Query = new Dictionary<string, string>();

        protected Endpoint(string host, string path)
        {
            Host = host;
            Path = path;
        }

        public IFlurlClient Http { get; set; }

        public string Host { get; set; }

        public string Path { get; set; }

        public Uri ToUri()
        {
            return new UriBuilder
            {
                Host = Host,
                Path = Path,
                Query = string.Join("&", Query.Select(entry => $"{entry.Key}={entry.Value}"))
            }.Uri;
        }
    }
}