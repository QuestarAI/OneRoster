namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class ResourceEndpoint : ItemEndpoint<Resource>
    {
        public ResourceEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}