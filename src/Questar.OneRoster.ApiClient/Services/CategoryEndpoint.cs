using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class CategoryEndpoint : EditItemEndpoint<Category>
    {
        public CategoryEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}