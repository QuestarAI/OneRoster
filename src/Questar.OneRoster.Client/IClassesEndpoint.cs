namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface IClassesEndpoint : IListEndpoint<Class>
    {
        IClassEndpoint For(Guid id);
    }
}