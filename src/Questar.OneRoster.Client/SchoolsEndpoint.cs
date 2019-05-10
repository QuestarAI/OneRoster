namespace Questar.OneRoster.Client
{
    using System;
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class SchoolsEndpoint : ListEndpoint<Org>
    {
        public SchoolsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public SchoolEndpoint For(string id) => new SchoolEndpoint(Http, $"{Path}/{id}");
    }
}