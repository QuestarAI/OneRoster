namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class CourseEndpoint : ItemEndpoint<Course>
    {
        public CourseEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public CourseClassesEndpoint Classes => new CourseClassesEndpoint(Http, $"{Path}/classes");
        public CourseResourcesEndpoint Resources => new CourseResourcesEndpoint(Http, $"{Path}/resources");
    }
}