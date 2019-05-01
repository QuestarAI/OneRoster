namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class EnrollmentsEndpoint : ListEndpoint<Enrollment>, IEnrollmentsEndpoint
    {
        public EnrollmentsEndpoint(string path) : base(path)
        {
        }

        public IItemEndpoint<Enrollment> For(Guid id) => new ItemEndpoint<Enrollment>($"{Path}/{id}");
    }
}