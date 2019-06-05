using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class OrgsEndpoint : ListEndpoint<Org>
    {
        public OrgsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public OrgEndpoint For(string id)
        {
            return new OrgEndpoint(Http, $"{Path}/{id}");
        }
    }
}