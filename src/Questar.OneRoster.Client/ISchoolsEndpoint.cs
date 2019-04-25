namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface ISchoolsEndpoint : IListEndpoint<Org>
    {
        ISchoolEndpoint For(Guid id);
    }
}