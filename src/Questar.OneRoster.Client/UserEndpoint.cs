namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class UserEndpoint : ItemEndpoint<User>
    {
        public UserEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public UserClassesEndpoint Classes => new UserClassesEndpoint(Http, $"{Path}/classes");
    }
}