namespace Questar.OneRoster.Client
{
    using Models;

    public interface ITeacherEndpoint : IItemEndpoint<User>
    {
        IListEndpoint<Class> Classes { get; }
    }
}