namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class UserClassesEndpoint : ListEndpoint<Class>
    {
        public UserClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}