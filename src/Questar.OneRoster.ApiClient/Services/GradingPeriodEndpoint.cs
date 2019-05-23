namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class GradingPeriodEndpoint : ItemEndpoint<AcademicSession>
    {
        public GradingPeriodEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}