namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class SchoolEnrollmentsEndpoint : ListEndpoint<Enrollment>
    {
        public SchoolEnrollmentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}