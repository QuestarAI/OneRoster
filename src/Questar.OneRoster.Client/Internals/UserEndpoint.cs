namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class UserEndpoint : ItemEndpoint<User>, IUserEndpoint
    {
        public UserEndpoint(string host, string path) : base(host, path)
        {
        }

        public IListEndpoint<Class> Classes { get; }
    }
}