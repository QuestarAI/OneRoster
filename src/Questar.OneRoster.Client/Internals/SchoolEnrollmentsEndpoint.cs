namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class SchoolEnrollmentsEndpoint : ListEndpoint<Enrollment>
    {
        public SchoolEnrollmentsEndpoint(string path) : base(path)
        {
        }
    }
}