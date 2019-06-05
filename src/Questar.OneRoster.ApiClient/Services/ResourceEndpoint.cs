using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class ResourceEndpoint : ItemEndpoint<Resource>
    {
        public ResourceEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}