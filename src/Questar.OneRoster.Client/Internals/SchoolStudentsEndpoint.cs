namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class SchoolStudentsEndpoint : ListEndpoint<User>
    {
        public SchoolStudentsEndpoint(string path) : base(path)
        {
        }
    }
}