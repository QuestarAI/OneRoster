namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class DemographicEndpoint : ItemEndpoint<Demographics>
    {
        public DemographicEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}