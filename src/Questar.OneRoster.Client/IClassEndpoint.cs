namespace Questar.OneRoster.Client
{
    using Models;

    public interface IClassEndpoint : IItemEndpoint<Class>
    {
        IClassLineItemsEndpoint LineItems { get; }

        IListEndpoint<Resource> Resources { get; }

        IListEndpoint<Result> Results { get; }

        IClassStudentsEndpoint Students { get; }

        IListEndpoint<User> Teachers { get; }
    }
}