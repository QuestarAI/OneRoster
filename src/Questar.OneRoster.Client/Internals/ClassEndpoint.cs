namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class ClassEndpoint : ItemEndpoint<Class>
    {
        public ClassEndpoint(string path) : base(path)
        {
        }

        public ClassLineItemsEndpoint LineItems => new ClassLineItemsEndpoint($"{Path}/lineItems") { Http = Http };
        public ClassResourcesEndpoint Resources => new ClassResourcesEndpoint($"{Path}/resources") { Http = Http };
        public ClassResultsEndpoint Results => new ClassResultsEndpoint($"{Path}/results") { Http = Http };
        public ClassStudentsEndpoint Students => new ClassStudentsEndpoint($"{Path}/students") { Http = Http };
        public ClassTeachersEndpoint Teachers => new ClassTeachersEndpoint($"{Path}/teachers") { Http = Http };
    }
}