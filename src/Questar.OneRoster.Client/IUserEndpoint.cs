namespace Questar.OneRoster.Client
{
    using Models;

    public interface IUserEndpoint : IListEndpoint<User>
    {
        IListEndpoint<Class> Classes { get; }
    }
}