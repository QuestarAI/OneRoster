using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class CourseClassesEndpoint : ListEndpoint<Class>
    {
        public CourseClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}