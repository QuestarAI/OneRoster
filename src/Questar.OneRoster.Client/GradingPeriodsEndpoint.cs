namespace Questar.OneRoster.Client
{
    using System;
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class GradingPeriodsEndpoint : ListEndpoint<AcademicSession>
    {
        public GradingPeriodsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public GradingPeriodEndpoint For(Guid id) => new GradingPeriodEndpoint(Http, $"{Path}/{id}");
    }
}