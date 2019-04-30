namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class GradingPeriodsEndpoint : ListEndpoint<AcademicSession>, IGradingPeriodsEndpoint
    {
        public GradingPeriodsEndpoint(string host, string path) : base(host, path)
        {
        }

        public IItemEndpoint<AcademicSession> For(Guid id) => throw new NotImplementedException();
    }
}