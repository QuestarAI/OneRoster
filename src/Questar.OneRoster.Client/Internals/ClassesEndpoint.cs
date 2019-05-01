namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class ClassesEndpoint : ListEndpoint<Class>
    {
        public ClassesEndpoint(string path) : base(path)
        {
        }

        public ClassEndpoint For(Guid id) => new ClassEndpoint($"{Path}/{id}") { Http = Http };
    }
}