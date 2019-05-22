namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class ClassLineItemResultsEndpoint : ListEndpoint<Result>
    {
        public ClassLineItemResultsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}