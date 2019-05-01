namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class ClassLineItemsEndpoint : ListEndpoint<LineItem>
    {
        public ClassLineItemsEndpoint(string path) : base(path)
        {
        }

        public ClassLineItemResultsEndpoint ResultsFor(Guid id) => new ClassLineItemResultsEndpoint($"{Path}/{id}/results") { Http = Http };
    }
}