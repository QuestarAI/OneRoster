namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class SchoolClassesEndpoint : ListEndpoint<Class>
    {
        public SchoolClassesEndpoint(string path) : base(path)
        {
        }

        public SchoolClassEndpoint For(Guid id) => new SchoolClassEndpoint($"{Path}/{id}") { Http = Http };
    }
}