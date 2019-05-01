namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class CourseClassesEndpoint : ListEndpoint<Class>
    {
        public CourseClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}