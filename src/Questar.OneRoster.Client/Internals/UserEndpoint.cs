namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class UserEndpoint : ItemEndpoint<User>
    {
        public UserEndpoint(string path) : base(path)
        {
        }

        public UserClassesEndpoint Classes => new UserClassesEndpoint($"{Path}/classes") { Http = Http };
    }
}