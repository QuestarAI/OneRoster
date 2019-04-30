namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class ResourcesEndpoint : ListEndpoint<Resource>, IResourcesEndpoint
    {
        public ResourcesEndpoint(string host, string path) : base(host, path)
        {
        }

        public IItemEndpoint<Resource> For(Guid id) => throw new NotImplementedException();
    }
}