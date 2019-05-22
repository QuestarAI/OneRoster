namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class UserEndpoint : ItemEndpoint<User>
    {
        public UserEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public UserClassesEndpoint Classes => new UserClassesEndpoint(Http, $"{Path}/classes");
    }
}