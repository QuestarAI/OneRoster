using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class LineItemsEndpoint : ListEndpoint<LineItem>
    {
        public LineItemsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public LineItemEndpoint For(string id)
        {
            return new LineItemEndpoint(Http, $"{Path}/{id}");
        }
    }
}