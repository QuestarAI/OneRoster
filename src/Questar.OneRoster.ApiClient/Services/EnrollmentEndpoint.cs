using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class EnrollmentEndpoint : ItemEndpoint<Enrollment>
    {
        public EnrollmentEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}