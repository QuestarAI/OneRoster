namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
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