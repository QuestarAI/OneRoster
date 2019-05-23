namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class CoursesEndpoint : ListEndpoint<Course>
    {
        public CoursesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public CourseEndpoint For(string id) =>
            new CourseEndpoint(Http, $"{Path}/{id}");
    }
}