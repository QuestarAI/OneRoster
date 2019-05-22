namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class DemographicsEndpoint : ListEndpoint<Demographics>
    {
        public DemographicsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public DemographicEndpoint For(string id) =>
            new DemographicEndpoint(Http, $"{Path}/{id}");
    }
}