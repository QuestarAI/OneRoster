using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class SchoolEnrollmentsEndpoint : ListEndpoint<Enrollment>
    {
        public SchoolEnrollmentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}