namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class TermEndpoint : ItemEndpoint<AcademicSession>
    {
        public TermEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public TermClassesEndpoint Classes => new TermClassesEndpoint(Http, $"{Path}/classes");

        public TermGradingPeriodsEndpoint GradingPeriods => new TermGradingPeriodsEndpoint(Http, $"{Path}/academicSessions");
    }
}