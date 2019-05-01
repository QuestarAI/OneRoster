namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class ClassTeachersEndpoint : ListEndpoint<User>
    {
        public ClassTeachersEndpoint(string path) : base(path)
        {
        }
    }
}