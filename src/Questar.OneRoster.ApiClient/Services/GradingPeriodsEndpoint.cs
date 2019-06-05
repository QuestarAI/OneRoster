using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class GradingPeriodsEndpoint : ListEndpoint<AcademicSession>
    {
        public GradingPeriodsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public GradingPeriodEndpoint For(string id)
        {
            return new GradingPeriodEndpoint(Http, $"{Path}/{id}");
        }
    }
}