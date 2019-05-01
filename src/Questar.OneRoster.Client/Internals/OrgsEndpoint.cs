namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class OrgsEndpoint : ListEndpoint<Org>
    {
        public OrgsEndpoint(string path) : base(path)
        {
        }

        public OrgEndpoint For(Guid id) => new OrgEndpoint($"{Path}/{id}") { Http = Http };
    }
}