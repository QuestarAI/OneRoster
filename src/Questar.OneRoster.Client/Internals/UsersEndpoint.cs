namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class UsersEndpoint : ListEndpoint<User>, IUsersEndpoint
    {
        public UsersEndpoint(string path) : base(path)
        {
        }

        public IUserEndpoint For(Guid id) => new UserEndpoint($"{Path}/{id}");
    }
}