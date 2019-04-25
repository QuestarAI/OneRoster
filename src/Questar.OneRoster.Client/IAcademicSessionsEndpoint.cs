namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface IAcademicSessionsEndpoint : IListEndpoint<AcademicSession>
    {
        IItemEndpoint<AcademicSession> For(Guid id);
    }
}