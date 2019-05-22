namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class GradingPeriodEndpoint : ItemEndpoint<AcademicSession>
    {
        public GradingPeriodEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}