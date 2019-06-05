using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class ClassResultsEndpoint : ListEndpoint<Result>
    {
        public ClassResultsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}