namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class UsersEndpoint : ListEndpoint<User>
    {
        public UsersEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public UserEndpoint For(string id) => new UserEndpoint(Http, $"{Path}/{id}");
    }
}