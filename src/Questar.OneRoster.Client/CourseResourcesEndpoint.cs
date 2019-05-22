namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class CourseResourcesEndpoint : ListEndpoint<Resource>
    {
        public CourseResourcesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}