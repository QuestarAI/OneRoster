namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class ResourcesEndpoint : ListEndpoint<Resource>
    {
        public ResourcesEndpoint(string path) : base(path)
        {
        }

        public ResourceEndpoint For(Guid id) => new ResourceEndpoint($"{Path}/{id}") { Http = Http };
    }
}