namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class CategoryEndpoint : EditItemEndpoint<Category>
    {
        public CategoryEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}