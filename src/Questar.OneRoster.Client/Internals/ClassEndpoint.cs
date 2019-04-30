namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class ClassEndpoint : ItemEndpoint<Class>, IClassEndpoint
    {
        public ClassEndpoint(string host, string path) : base(host, path)
        {
        }

        public IClassLineItemsEndpoint LineItems { get; }
        public IListEndpoint<Resource> Resources { get; }
        public IListEndpoint<Result> Results { get; }
        public IClassStudentsEndpoint Students { get; }
        public IListEndpoint<User> Teachers { get; }
    }
}