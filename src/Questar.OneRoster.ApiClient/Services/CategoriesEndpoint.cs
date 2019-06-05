using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class CategoriesEndpoint : ListEndpoint<Category>
    {
        public CategoriesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public CategoryEndpoint For(string id)
        {
            return new CategoryEndpoint(Http, $"{Path}/{id}");
        }
    }
}