using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class SchoolClassEnrollmentsEndpoint : ListEndpoint<Enrollment>
    {
        public SchoolClassEnrollmentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}