namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface IGradingPeriodsEndpoint : IListEndpoint<AcademicSession>
    {
        IItemEndpoint<AcademicSession> For(Guid id);
    }
}