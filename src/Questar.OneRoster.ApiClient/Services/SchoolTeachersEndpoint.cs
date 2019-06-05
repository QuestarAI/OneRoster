using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class SchoolTeachersEndpoint : ListEndpoint<User>
    {
        public SchoolTeachersEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}