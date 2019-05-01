namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class TermGradingPeriodsEndpoint : ListEndpoint<AcademicSession>
    {
        public TermGradingPeriodsEndpoint(string path) : base(path)
        {
        }
    }
}