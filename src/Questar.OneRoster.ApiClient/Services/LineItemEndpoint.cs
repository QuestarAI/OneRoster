namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class LineItemEndpoint : EditItemEndpoint<LineItem>
    {
        public LineItemEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}