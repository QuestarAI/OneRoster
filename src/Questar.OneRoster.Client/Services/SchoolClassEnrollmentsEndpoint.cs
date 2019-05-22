namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class SchoolClassEnrollmentsEndpoint : ListEndpoint<Enrollment>
    {
        public SchoolClassEnrollmentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}