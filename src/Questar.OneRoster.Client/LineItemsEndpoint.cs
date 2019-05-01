namespace Questar.OneRoster.Client
{
    using System;
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class LineItemsEndpoint : ListEndpoint<LineItem>
    {
        public LineItemsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public LineItemEndpoint For(Guid id) => new LineItemEndpoint(Http, $"{Path}/{id}");
    }
}