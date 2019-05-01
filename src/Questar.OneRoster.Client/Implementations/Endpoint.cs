namespace Questar.OneRoster.Client.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Flurl.Http;

    public abstract class Endpoint<T>
    {
        protected readonly IDictionary<string, string> Query = new Dictionary<string, string>();

        protected Endpoint(string path)
        {
            Path = path;
        }

        public IFlurlClient Http { get; set; }

        public string Host { get; set; }

        public string Path { get; set; }

        public string ToUri()
        {
            return $"{Path}?{string.Join("&", Query.Select(entry => $"{entry.Key}={entry.Value}"))}";
        }
    }
}