namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class ResourceEndpoint : ItemEndpoint<Resource>
    {
        public ResourceEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}