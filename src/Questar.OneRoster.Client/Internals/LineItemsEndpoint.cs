namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class LineItemsEndpoint : ListEndpoint<LineItem>
    {
        public LineItemsEndpoint(string path) : base(path)
        {
        }

        public LineItemEndpoint For(Guid id) => new LineItemEndpoint($"{Path}/{id}") { Http = Http };
    }
}