namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class CourseResourcesEndpoint : ListEndpoint<Resource>
    {
        public CourseResourcesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}