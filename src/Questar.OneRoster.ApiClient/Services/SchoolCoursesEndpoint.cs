using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class SchoolCoursesEndpoint : ListEndpoint<Course>
    {
        public SchoolCoursesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}