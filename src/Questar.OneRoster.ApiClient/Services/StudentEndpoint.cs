using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class StudentEndpoint : ItemEndpoint<User>
    {
        public StudentEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public StudentClassesEndpoint Classes => new StudentClassesEndpoint(Http, $"{Path}/classes");
    }
}