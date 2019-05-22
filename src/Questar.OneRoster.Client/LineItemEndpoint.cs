namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class LineItemEndpoint : EditItemEndpoint<LineItem>
    {
        public LineItemEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}