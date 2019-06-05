using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class ClassesEndpoint : ListEndpoint<Class>
    {
        public ClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public ClassEndpoint For(string id)
        {
            return new ClassEndpoint(Http, $"{Path}/{id}");
        }
    }
}