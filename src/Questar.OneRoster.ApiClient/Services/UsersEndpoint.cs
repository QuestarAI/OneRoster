using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class UsersEndpoint : ListEndpoint<User>
    {
        public UsersEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public UserEndpoint For(string id)
        {
            return new UserEndpoint(Http, $"{Path}/{id}");
        }
    }
}