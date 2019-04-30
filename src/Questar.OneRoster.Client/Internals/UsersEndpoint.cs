namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class UsersEndpoint : ListEndpoint<User>, IUsersEndpoint
    {
        public UsersEndpoint(string host, string path) : base(host, path)
        {
        }

        public IUserEndpoint For(Guid id) => throw new NotImplementedException();
    }
}