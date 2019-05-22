namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class EnrollmentsEndpoint : ListEndpoint<Enrollment>
    {
        public EnrollmentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public EnrollmentEndpoint For(string id) =>
            new EnrollmentEndpoint(Http, $"{Path}/{id}");
    }
}