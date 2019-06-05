using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class SchoolStudentsEndpoint : ListEndpoint<User>
    {
        public SchoolStudentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}