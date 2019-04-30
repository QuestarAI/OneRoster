namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class ClassesEndpoint : ListEndpoint<Class>, IClassesEndpoint
    {
        public ClassesEndpoint(string host, string path) : base(host, path)
        {
        }

        public IClassEndpoint For(Guid id) => throw new NotImplementedException();
    }
}