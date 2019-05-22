namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class ClassEndpoint : ItemEndpoint<Class>
    {
        public ClassEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public ClassLineItemsEndpoint LineItems => new ClassLineItemsEndpoint(Http, $"{Path}/lineItems");
        public ClassResourcesEndpoint Resources => new ClassResourcesEndpoint(Http, $"{Path}/resources");
        public ClassResultsEndpoint Results => new ClassResultsEndpoint(Http, $"{Path}/results");
        public ClassStudentsEndpoint Students => new ClassStudentsEndpoint(Http, $"{Path}/students");
        public ClassTeachersEndpoint Teachers => new ClassTeachersEndpoint(Http, $"{Path}/teachers");
    }
}