namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class TermEndpoint : ListEndpoint<AcademicSession>
    {
        public TermEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public TermClassesEndpoint Classes => new TermClassesEndpoint(Http, $"{Path}/classes");

        public TermGradingPeriodsEndpoint GradingPeriods => new TermGradingPeriodsEndpoint(Http, $"{Path}/academicSessions");
    }
}