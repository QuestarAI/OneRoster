using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class AcademicSessionsEndpoint : ListEndpoint<AcademicSession>
    {
        public AcademicSessionsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public AcademicSessionEndpoint For(string id)
        {
            return new AcademicSessionEndpoint(Http, $"{Path}/{id}");
        }
    }
}