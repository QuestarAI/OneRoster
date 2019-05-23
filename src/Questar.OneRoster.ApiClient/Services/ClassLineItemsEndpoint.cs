namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class ClassLineItemsEndpoint : ListEndpoint<LineItem>
    {
        public ClassLineItemsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public ClassLineItemResultsEndpoint ResultsFor(string id) =>
            new ClassLineItemResultsEndpoint(Http, $"{Path}/{id}/results");
    }
}