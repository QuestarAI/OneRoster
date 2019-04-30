namespace Questar.OneRoster.Client
{
    using Models;

    public interface IUserEndpoint : IItemEndpoint<User>
    {
        IListEndpoint<Class> Classes { get; }
    }
}