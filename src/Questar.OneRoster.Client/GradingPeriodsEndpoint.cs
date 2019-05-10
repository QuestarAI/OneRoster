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

        public GradingPeriodEndpoint For(string id) => new GradingPeriodEndpoint(Http, $"{Path}/{id}");
    }
}