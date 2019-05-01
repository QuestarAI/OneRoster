namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class TermEndpoint : ListEndpoint<AcademicSession>, ITermEndpoint
    {
        public TermEndpoint(string path) : base(path)
        {
        }

        public IListEndpoint<Class> Classes => new ListEndpoint<Class>($"{Path}/classes");

        public IListEndpoint<AcademicSession> GradingPeriods => new ListEndpoint<AcademicSession>($"{Path}/academicSessions");
    }
}