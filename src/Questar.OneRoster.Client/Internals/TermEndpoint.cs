namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class TermEndpoint : ListEndpoint<AcademicSession>
    {
        public TermEndpoint(string path) : base(path)
        {
        }

        public TermClassesEndpoint Classes => new TermClassesEndpoint($"{Path}/classes") { Http = Http };

        public TermGradingPeriodsEndpoint GradingPeriods => new TermGradingPeriodsEndpoint($"{Path}/academicSessions") { Http = Http };
    }
}