namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class ClassStudentLineItemsEndpoint : ListEndpoint<LineItem>
    {
        public ClassStudentLineItemsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}