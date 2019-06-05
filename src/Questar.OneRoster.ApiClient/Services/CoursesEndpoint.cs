using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class CoursesEndpoint : ListEndpoint<Course>
    {
        public CoursesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public CourseEndpoint For(string id)
        {
            return new CourseEndpoint(Http, $"{Path}/{id}");
        }
    }
}