namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class ClassStudentsEndpoint : ListEndpoint<User>
    {
        public ClassStudentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public ClassStudentLineItemsEndpoint ResultsFor(string id) =>
            new ClassStudentLineItemsEndpoint(Http, $"{Path}/{id}/lineItems");
    }
}