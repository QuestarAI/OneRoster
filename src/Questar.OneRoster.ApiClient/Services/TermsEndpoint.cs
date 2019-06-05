using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class TermsEndpoint : ListEndpoint<AcademicSession>
    {
        public TermsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public TermEndpoint For(string id)
        {
            return new TermEndpoint(Http, $"{Path}/{id}");
        }
    }
}