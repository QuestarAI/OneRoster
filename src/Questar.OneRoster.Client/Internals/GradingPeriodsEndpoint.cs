namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class GradingPeriodsEndpoint : ListEndpoint<AcademicSession>, IGradingPeriodsEndpoint
    {
        public GradingPeriodsEndpoint(string path) : base(path)
        {
        }

        public IItemEndpoint<AcademicSession> For(Guid id) => new ItemEndpoint<AcademicSession>($"{Path}/{id}");
    }
}