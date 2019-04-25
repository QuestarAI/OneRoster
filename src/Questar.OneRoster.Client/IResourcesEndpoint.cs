namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface IResourcesEndpoint : IListEndpoint<Resource>
    {
        IItemEndpoint<Resource> For(Guid id);
    }
}