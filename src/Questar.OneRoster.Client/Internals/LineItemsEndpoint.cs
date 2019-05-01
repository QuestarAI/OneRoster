namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class LineItemsEndpoint : ListEndpoint<LineItem>, ILineItemsEndpoint
    {
        public LineItemsEndpoint(string path) : base(path)
        {
        }

        public IEditEndpoint<LineItem> For(Guid id) => new EditEndpoint<LineItem>($"{Path}/{id}");
    }
}