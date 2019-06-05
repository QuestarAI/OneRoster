using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class DemographicsEndpoint : ListEndpoint<Demographics>
    {
        public DemographicsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public DemographicEndpoint For(string id)
        {
            return new DemographicEndpoint(Http, $"{Path}/{id}");
        }
    }
}