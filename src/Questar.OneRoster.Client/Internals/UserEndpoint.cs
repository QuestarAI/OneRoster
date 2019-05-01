namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class UserEndpoint : ItemEndpoint<User>, IUserEndpoint
    {
        public UserEndpoint(string path) : base(path)
        {
        }

        public IListEndpoint<Class> Classes => new ListEndpoint<Class>($"{Path}/classes");
    }
}