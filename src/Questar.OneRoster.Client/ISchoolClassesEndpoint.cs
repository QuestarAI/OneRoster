namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface ISchoolClassesEndpoint : IListEndpoint<Org>
    {
        ISchoolClassEndpoint For(Guid id);
    }
}