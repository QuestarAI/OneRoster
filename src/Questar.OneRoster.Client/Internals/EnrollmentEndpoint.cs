namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class EnrollmentEndpoint : ItemEndpoint<Enrollment>
    {
        public EnrollmentEndpoint(string path) : base(path)
        {
        }
    }
}