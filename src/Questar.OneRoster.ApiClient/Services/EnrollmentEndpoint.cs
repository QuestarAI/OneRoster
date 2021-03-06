namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class EnrollmentEndpoint : ItemEndpoint<Enrollment>
    {
        public EnrollmentEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}