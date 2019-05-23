namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class OrgsEndpoint : ListEndpoint<Org>
    {
        public OrgsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public OrgEndpoint For(string id) =>
            new OrgEndpoint(Http, $"{Path}/{id}");
    }
}