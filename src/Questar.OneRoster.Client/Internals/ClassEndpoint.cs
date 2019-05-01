namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class ClassEndpoint : ItemEndpoint<Class>, IClassEndpoint
    {
        public ClassEndpoint(string path) : base(path)
        {
        }

        public IClassLineItemsEndpoint LineItems => new ClassLineItemsEndpoint($"{Path}/lineItems");
        public IListEndpoint<Resource> Resources => new ListEndpoint<Resource>($"{Path}/resources");
        public IListEndpoint<Result> Results => new ListEndpoint<Result>($"{Path}/results");
        public IClassStudentsEndpoint Students => new ClassStudentsEndpoint($"{Path}/students");
        public IListEndpoint<User> Teachers => new ListEndpoint<User>($"{Path}/teachers");
    }
}