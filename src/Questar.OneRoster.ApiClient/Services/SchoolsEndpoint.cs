using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class SchoolsEndpoint : ListEndpoint<Org>
    {
        public SchoolsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public SchoolEndpoint For(string id)
        {
            return new SchoolEndpoint(Http, $"{Path}/{id}");
        }
    }
}