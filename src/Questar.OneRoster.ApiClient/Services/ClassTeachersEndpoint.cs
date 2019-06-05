using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class ClassTeachersEndpoint : ListEndpoint<User>
    {
        public ClassTeachersEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}