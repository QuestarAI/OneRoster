namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class SchoolClassTeachersEndpoint : ListEndpoint<User>
    {
        public SchoolClassTeachersEndpoint(string path) : base(path)
        {
        }
    }
}