using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class ClassLineItemResultsEndpoint : ListEndpoint<Result>
    {
        public ClassLineItemResultsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}