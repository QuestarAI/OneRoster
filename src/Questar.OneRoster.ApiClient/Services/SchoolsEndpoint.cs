namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class SchoolsEndpoint : ListEndpoint<Org>
    {
        public SchoolsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public SchoolEndpoint For(string id) =>
            new SchoolEndpoint(Http, $"{Path}/{id}");
    }
}