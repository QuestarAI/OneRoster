using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class TeachersEndpoint : ListEndpoint<User>
    {
        public TeachersEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public TeacherEndpoint For(string id)
        {
            return new TeacherEndpoint(Http, $"{Path}/{id}");
        }
    }
}