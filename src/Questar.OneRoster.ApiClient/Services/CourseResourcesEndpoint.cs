using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class CourseResourcesEndpoint : ListEndpoint<Resource>
    {
        public CourseResourcesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}