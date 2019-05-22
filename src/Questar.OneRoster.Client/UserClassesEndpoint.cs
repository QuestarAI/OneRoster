namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class UserClassesEndpoint : ListEndpoint<Class>
    {
        public UserClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}