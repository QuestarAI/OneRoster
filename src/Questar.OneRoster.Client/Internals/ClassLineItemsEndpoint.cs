namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class ClassLineItemsEndpoint : ListEndpoint<LineItem>, IClassLineItemsEndpoint
    {
        public ClassLineItemsEndpoint(string path) : base(path)
        {
        }

        public IListEndpoint<Result> ResultsFor(Guid id) => new ListEndpoint<Result>($"{Path}/results");
    }
}