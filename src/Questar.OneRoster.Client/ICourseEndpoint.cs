namespace Questar.OneRoster.Client
{
    using Models;

    public interface ICourseEndpoint : IItemEndpoint<Course>
    {
        IListEndpoint<Class> Classes { get; }

        IListEndpoint<Resource> Resources { get; }
    }
}