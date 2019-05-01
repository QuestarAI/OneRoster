namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class UserClassesEndpoint : ListEndpoint<Class>
    {
        public UserClassesEndpoint(string path) : base(path)
        {
        }
    }
}