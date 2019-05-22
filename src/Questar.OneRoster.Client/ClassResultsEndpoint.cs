namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class ClassResultsEndpoint : ListEndpoint<Result>
    {
        public ClassResultsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}