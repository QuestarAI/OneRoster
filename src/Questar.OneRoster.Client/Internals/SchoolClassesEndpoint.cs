namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class SchoolClassesEndpoint : ListEndpoint<Class>, ISchoolClassesEndpoint
    {
        public SchoolClassesEndpoint(string host, string path) : base(host, path)
        {
        }

        public ISchoolClassEndpoint For(Guid id) => throw new NotImplementedException();
    }
}