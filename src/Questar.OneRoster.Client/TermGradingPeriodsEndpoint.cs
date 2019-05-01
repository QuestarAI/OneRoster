namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class TermGradingPeriodsEndpoint : ListEndpoint<AcademicSession>
    {
        public TermGradingPeriodsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}