namespace Questar.OneRoster.Client
{
    using System;
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class DemographicsEndpoint : ListEndpoint<Demographics>
    {
        public DemographicsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public DemographicEndpoint For(string id) => new DemographicEndpoint(Http, $"{Path}/{id}");
    }
}