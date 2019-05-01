namespace Questar.OneRoster.Client
{
    using System;
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class EnrollmentsEndpoint : ListEndpoint<Enrollment>
    {
        public EnrollmentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public EnrollmentEndpoint For(Guid id) => new EnrollmentEndpoint(Http, $"{Path}/{id}");
    }
}