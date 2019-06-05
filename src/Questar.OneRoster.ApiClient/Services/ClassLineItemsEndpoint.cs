using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class ClassLineItemsEndpoint : ListEndpoint<LineItem>
    {
        public ClassLineItemsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public ClassLineItemResultsEndpoint ResultsFor(string id)
        {
            return new ClassLineItemResultsEndpoint(Http, $"{Path}/{id}/results");
        }
    }
}