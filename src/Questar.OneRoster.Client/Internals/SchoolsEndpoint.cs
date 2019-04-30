namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class SchoolsEndpoint : ListEndpoint<Org>, ISchoolsEndpoint
    {
        public SchoolsEndpoint(string host, string path) : base(host, path)
        {
        }

        public ISchoolEndpoint For(Guid id) => throw new NotImplementedException();
    }
}