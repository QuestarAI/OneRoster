namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface IClassLineItemsEndpoint : IListEndpoint<LineItem>
    {
        IListEndpoint<Result> ResultsFor(Guid id);
    }
}