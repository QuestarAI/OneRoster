namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class SchoolClassEnrollmentsEndpoint : ListEndpoint<Enrollment>
    {
        public SchoolClassEnrollmentsEndpoint(string path) : base(path)
        {
        }
    }
}