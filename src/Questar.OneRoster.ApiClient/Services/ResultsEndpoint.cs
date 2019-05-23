namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class ResultsEndpoint : ListEndpoint<Result>
    {
        public ResultsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public ResultEndpoint For(string id) =>
            new ResultEndpoint(Http, $"{Path}/{id}");
    }
}