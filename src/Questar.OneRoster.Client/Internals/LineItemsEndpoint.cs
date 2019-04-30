namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class LineItemsEndpoint : ListEndpoint<LineItem>, ILineItemsEndpoint
    {
        public LineItemsEndpoint(string host, string path) : base(host, path)
        {
        }

        public IEditEndpoint<LineItem> For(Guid id) => throw new NotImplementedException();
    }
}