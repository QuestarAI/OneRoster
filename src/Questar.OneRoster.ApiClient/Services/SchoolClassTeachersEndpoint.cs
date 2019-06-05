using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class SchoolClassTeachersEndpoint : ListEndpoint<User>
    {
        public SchoolClassTeachersEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}