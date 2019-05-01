namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class SchoolClassesEndpoint : ListEndpoint<Class>, ISchoolClassesEndpoint
    {
        public SchoolClassesEndpoint(string path) : base(path)
        {
        }

        public ISchoolClassEndpoint For(Guid id) => new SchoolClassEndpoint($"{Path}/{id}");
    }
}