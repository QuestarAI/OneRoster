namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class SchoolEnrollmentsEndpoint : ListEndpoint<Enrollment>
    {
        public SchoolEnrollmentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}