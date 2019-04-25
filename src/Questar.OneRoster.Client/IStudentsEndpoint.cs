namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface IStudentsEndpoint : IListEndpoint<User>
    {
        IStudentEndpoint For(Guid id);
    }
}