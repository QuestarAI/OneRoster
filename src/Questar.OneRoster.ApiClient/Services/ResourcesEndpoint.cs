using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class ResourcesEndpoint : ListEndpoint<Resource>
    {
        public ResourcesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public ResourceEndpoint For(string id)
        {
            return new ResourceEndpoint(Http, $"{Path}/{id}");
        }
    }
}