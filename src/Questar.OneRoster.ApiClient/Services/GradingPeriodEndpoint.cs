using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class GradingPeriodEndpoint : ItemEndpoint<AcademicSession>
    {
        public GradingPeriodEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}