namespace Questar.OneRoster.Client
{
    using Models;

    public interface IStudentEndpoint : IItemEndpoint<User>
    {
        IListEndpoint<Class> Classes { get; }
    }
}