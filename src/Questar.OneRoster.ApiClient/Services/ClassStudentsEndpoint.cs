using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class ClassStudentsEndpoint : ListEndpoint<User>
    {
        public ClassStudentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public ClassStudentLineItemsEndpoint ResultsFor(string id)
        {
            return new ClassStudentLineItemsEndpoint(Http, $"{Path}/{id}/lineItems");
        }
    }
}