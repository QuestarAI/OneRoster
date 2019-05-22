namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class ResourcesEndpoint : ListEndpoint<Resource>
    {
        public ResourcesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public ResourceEndpoint For(string id) => new ResourceEndpoint(Http, $"{Path}/{id}");
    }
}