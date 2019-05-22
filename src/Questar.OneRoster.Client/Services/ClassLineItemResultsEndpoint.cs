namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class ClassLineItemResultsEndpoint : ListEndpoint<Result>
    {
        public ClassLineItemResultsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}