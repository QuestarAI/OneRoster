using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class UserEndpoint : ItemEndpoint<User>
    {
        public UserEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public UserClassesEndpoint Classes => new UserClassesEndpoint(Http, $"{Path}/classes");
    }
}