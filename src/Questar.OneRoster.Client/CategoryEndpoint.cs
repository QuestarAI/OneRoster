namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class CategoryEndpoint : EditItemEndpoint<Category>
    {
        public CategoryEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}