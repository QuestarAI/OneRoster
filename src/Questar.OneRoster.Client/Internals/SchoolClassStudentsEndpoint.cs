namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class SchoolClassStudentsEndpoint : ListEndpoint<User>
    {
        public SchoolClassStudentsEndpoint(string path) : base(path)
        {
        }
    }
}