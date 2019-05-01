namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class SchoolTermsEndpoint : ListEndpoint<AcademicSession>
    {
        public SchoolTermsEndpoint(string path) : base(path)
        {
        }
    }
}