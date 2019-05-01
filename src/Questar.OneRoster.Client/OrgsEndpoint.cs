namespace Questar.OneRoster.Client
{
    using System;
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class OrgsEndpoint : ListEndpoint<Org>
    {
        public OrgsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public OrgEndpoint For(Guid id) => new OrgEndpoint(Http, $"{Path}/{id}");
    }
}