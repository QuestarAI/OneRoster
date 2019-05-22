namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class SchoolClassEnrollmentsEndpoint : ListEndpoint<Enrollment>
    {
        public SchoolClassEnrollmentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}