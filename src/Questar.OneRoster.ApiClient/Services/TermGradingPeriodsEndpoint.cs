using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class TermGradingPeriodsEndpoint : ListEndpoint<AcademicSession>
    {
        public TermGradingPeriodsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}