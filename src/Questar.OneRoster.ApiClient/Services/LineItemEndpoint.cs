using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class LineItemEndpoint : EditItemEndpoint<LineItem>
    {
        public LineItemEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}