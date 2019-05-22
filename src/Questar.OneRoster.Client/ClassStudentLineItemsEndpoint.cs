namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class ClassStudentLineItemsEndpoint : ListEndpoint<LineItem>
    {
        public ClassStudentLineItemsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}