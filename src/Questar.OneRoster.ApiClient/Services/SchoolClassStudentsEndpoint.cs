using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class SchoolClassStudentsEndpoint : ListEndpoint<User>
    {
        public SchoolClassStudentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}