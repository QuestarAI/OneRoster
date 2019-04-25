namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface ITermsEndpoint : IListEndpoint<AcademicSession>
    {
        ITermEndpoint For(Guid id);
    }
}