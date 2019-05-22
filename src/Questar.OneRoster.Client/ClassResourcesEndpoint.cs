namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class ClassResourcesEndpoint : ListEndpoint<Resource>
    {
        public ClassResourcesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}