using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class ClassResourcesEndpoint : ListEndpoint<Resource>
    {
        public ClassResourcesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}