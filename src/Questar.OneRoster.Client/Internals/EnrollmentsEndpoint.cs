namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class EnrollmentsEndpoint : ListEndpoint<Enrollment>
    {
        public EnrollmentsEndpoint(string path) : base(path)
        {
        }

        public EnrollmentEndpoint For(Guid id) => new EnrollmentEndpoint($"{Path}/{id}") { Http = Http };
    }
}