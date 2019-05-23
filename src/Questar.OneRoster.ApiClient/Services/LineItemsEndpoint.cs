namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class LineItemsEndpoint : ListEndpoint<LineItem>
    {
        public LineItemsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public LineItemEndpoint For(string id) =>
            new LineItemEndpoint(Http, $"{Path}/{id}");
    }
}