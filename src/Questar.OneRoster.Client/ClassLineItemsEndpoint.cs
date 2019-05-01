namespace Questar.OneRoster.Client
{
    using System;
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class ClassLineItemsEndpoint : ListEndpoint<LineItem>
    {
        public ClassLineItemsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public ClassLineItemResultsEndpoint ResultsFor(Guid id) => new ClassLineItemResultsEndpoint(Http, $"{Path}/{id}/results");
    }
}