namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class SchoolTermsEndpoint : ListEndpoint<AcademicSession>
    {
        public SchoolTermsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}