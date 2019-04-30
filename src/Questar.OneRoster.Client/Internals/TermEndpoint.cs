namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class TermEndpoint : ListEndpoint<AcademicSession>, ITermEndpoint
    {
        public TermEndpoint(string host, string path) : base(host, path)
        {
        }

        public IListEndpoint<Class> Classes { get; }
        public IListEndpoint<AcademicSession> GradingPeriods { get; }
    }
}