using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class SchoolTermsEndpoint : ListEndpoint<AcademicSession>
    {
        public SchoolTermsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}