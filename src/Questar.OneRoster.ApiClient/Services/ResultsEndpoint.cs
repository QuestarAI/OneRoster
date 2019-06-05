using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class ResultsEndpoint : ListEndpoint<Result>
    {
        public ResultsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public ResultEndpoint For(string id)
        {
            return new ResultEndpoint(Http, $"{Path}/{id}");
        }
    }
}