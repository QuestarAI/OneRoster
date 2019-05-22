namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class CourseClassesEndpoint : ListEndpoint<Class>
    {
        public CourseClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}