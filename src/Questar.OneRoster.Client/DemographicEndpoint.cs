namespace Questar.OneRoster.Client
{
    using System;
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class DemographicEndpoint : ListEndpoint<Demographics>
    {
        public DemographicEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public DemographicsEndpoint For(Guid id) => new DemographicsEndpoint(Http, $"{Path}/{id}");
    }
}