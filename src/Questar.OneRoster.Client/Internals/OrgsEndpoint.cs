namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class OrgsEndpoint : ListEndpoint<Org>, IOrgsEndpoint
    {
        public OrgsEndpoint(string path) : base(path)
        {
        }

        public IItemEndpoint<Org> For(Guid id) => new ItemEndpoint<Org>($"{Path}/{id}");
    }
}