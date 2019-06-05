using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class SchoolClassesEndpoint : ListEndpoint<Class>
    {
        public SchoolClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public SchoolClassEndpoint For(string id)
        {
            return new SchoolClassEndpoint(Http, $"{Path}/{id}");
        }
    }
}