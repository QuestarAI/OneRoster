namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface IOrgsEndpoint : IListEndpoint<Org>
    {
        IItemEndpoint<Org> For(Guid id);
    }
}