namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class ResourcesEndpoint : ListEndpoint<Resource>, IResourcesEndpoint
    {
        public ResourcesEndpoint(string path) : base(path)
        {
        }

        public IItemEndpoint<Resource> For(Guid id) => new ItemEndpoint<Resource>($"{Path}/{id}");
    }
}