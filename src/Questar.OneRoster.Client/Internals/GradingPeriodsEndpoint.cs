namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class GradingPeriodsEndpoint : ListEndpoint<AcademicSession>
    {
        public GradingPeriodsEndpoint(string path) : base(path)
        {
        }

        public GradingPeriodEndpoint For(Guid id) => new GradingPeriodEndpoint($"{Path}/{id}") { Http = Http };
    }
}