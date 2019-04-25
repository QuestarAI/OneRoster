namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface ITeachersEndpoint : IListEndpoint<User>
    {
        ITeacherEndpoint For(Guid id);
    }
}