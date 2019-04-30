namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class OrgsEndpoint : ListEndpoint<Org>, IOrgsEndpoint
    {
        public OrgsEndpoint(string host, string path) : base(host, path)
        {
        }

        public IItemEndpoint<Org> For(Guid id) => throw new NotImplementedException();
    }
}