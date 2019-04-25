namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface IClassStudentsEndpoint : IListEndpoint<User>
    {
        IListEndpoint<Result> ResultsFor(Guid id);
    }
}