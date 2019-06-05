using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class EnrollmentsEndpoint : ListEndpoint<Enrollment>
    {
        public EnrollmentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public EnrollmentEndpoint For(string id)
        {
            return new EnrollmentEndpoint(Http, $"{Path}/{id}");
        }
    }
}