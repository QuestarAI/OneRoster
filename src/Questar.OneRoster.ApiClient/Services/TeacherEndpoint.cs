using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class TeacherEndpoint : ItemEndpoint<User>
    {
        public TeacherEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public TeacherClassesEndpoint Classes => new TeacherClassesEndpoint(Http, $"{Path}/classes");
    }
}