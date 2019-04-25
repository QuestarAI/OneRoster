namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface ILineItemsEndpoint : IListEndpoint<LineItem>
    {
        IEditEndpoint<LineItem> For(Guid id);
    }
}