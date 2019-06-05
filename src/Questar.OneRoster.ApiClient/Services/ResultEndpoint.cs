using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class ResultEndpoint : EditItemEndpoint<Result>
    {
        public ResultEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}