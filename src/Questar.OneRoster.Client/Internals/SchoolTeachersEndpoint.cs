namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class SchoolTeachersEndpoint : ListEndpoint<User>
    {
        public SchoolTeachersEndpoint(string path) : base(path)
        {
        }
    }
}