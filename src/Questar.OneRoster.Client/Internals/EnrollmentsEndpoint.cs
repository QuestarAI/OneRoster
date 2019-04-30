namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class EnrollmentsEndpoint : ListEndpoint<Enrollment>, IEnrollmentsEndpoint
    {
        public EnrollmentsEndpoint(string host, string path) : base(host, path)
        {
        }

        public IItemEndpoint<Enrollment> For(Guid id) => throw new NotImplementedException();
    }
}