using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class CourseEndpoint : ItemEndpoint<Course>
    {
        public CourseEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public CourseClassesEndpoint Classes => new CourseClassesEndpoint(Http, $"{Path}/classes");
        public CourseResourcesEndpoint Resources => new CourseResourcesEndpoint(Http, $"{Path}/resources");
    }
}