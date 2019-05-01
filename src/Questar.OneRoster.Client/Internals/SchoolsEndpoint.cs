namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class SchoolsEndpoint : ListEndpoint<Org>, ISchoolsEndpoint
    {
        public SchoolsEndpoint(string path) : base(path)
        {
        }

        public ISchoolEndpoint For(Guid id) => new SchoolEndpoint($"{Path}/{id}");
    }
}