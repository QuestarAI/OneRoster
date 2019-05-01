namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class UsersEndpoint : ListEndpoint<User>
    {
        public UsersEndpoint(string path) : base(path)
        {
        }

        public UserEndpoint For(Guid id) => new UserEndpoint($"{Path}/{id}") { Http = Http };
    }
}