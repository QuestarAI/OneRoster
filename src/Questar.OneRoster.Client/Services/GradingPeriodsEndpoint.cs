namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class GradingPeriodsEndpoint : ListEndpoint<AcademicSession>
    {
        public GradingPeriodsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public GradingPeriodEndpoint For(string id) =>
            new GradingPeriodEndpoint(Http, $"{Path}/{id}");
    }
}