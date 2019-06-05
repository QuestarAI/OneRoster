using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class StudentsEndpoint : ListEndpoint<User>
    {
        public StudentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public StudentEndpoint For(string id)
        {
            return new StudentEndpoint(Http, $"{Path}/{id}");
        }
    }
}