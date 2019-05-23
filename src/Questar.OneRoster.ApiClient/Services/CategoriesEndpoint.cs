namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class CategoriesEndpoint : ListEndpoint<Category>
    {
        public CategoriesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public CategoryEndpoint For(string id) =>
            new CategoryEndpoint(Http, $"{Path}/{id}");
    }
}