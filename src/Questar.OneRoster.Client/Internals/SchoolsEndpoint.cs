namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class SchoolsEndpoint : ListEndpoint<Org>
    {
        public SchoolsEndpoint(string path) : base(path)
        {
        }

        public SchoolEndpoint For(Guid id) => new SchoolEndpoint($"{Path}/{id}") { Http = Http };
    }
}