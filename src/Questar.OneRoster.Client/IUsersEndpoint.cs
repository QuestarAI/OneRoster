namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface IUsersEndpoint : IListEndpoint<User>
    {
        IUserEndpoint For(Guid id);
    }
}