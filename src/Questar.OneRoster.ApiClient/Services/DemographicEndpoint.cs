using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class DemographicEndpoint : ItemEndpoint<Demographics>
    {
        public DemographicEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}