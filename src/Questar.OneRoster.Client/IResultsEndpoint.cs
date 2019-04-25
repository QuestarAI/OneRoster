namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface IResultsEndpoint : IListEndpoint<Result>
    {
        IEditEndpoint<Result> For(Guid id);
    }
}