namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class EnrollmentEndpoint : ItemEndpoint<Enrollment>
    {
        public EnrollmentEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}