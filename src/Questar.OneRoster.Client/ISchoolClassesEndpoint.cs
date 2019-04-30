namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface ISchoolClassesEndpoint : IListEndpoint<Class>
    {
        ISchoolClassEndpoint For(Guid id);
    }
}