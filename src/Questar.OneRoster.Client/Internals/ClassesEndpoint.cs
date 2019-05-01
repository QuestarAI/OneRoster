namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class ClassesEndpoint : ListEndpoint<Class>, IClassesEndpoint
    {
        public ClassesEndpoint(string path) : base(path)
        {
        }

        public IClassEndpoint For(Guid id) => new ClassEndpoint($"{Path}/{{id}}");
    }
}