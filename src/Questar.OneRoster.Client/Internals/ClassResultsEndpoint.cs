namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class ClassResultsEndpoint : ListEndpoint<Result>
    {
        public ClassResultsEndpoint(string path) : base(path)
        {
        }
    }
}