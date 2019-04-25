namespace Questar.OneRoster.Client
{
    using Models;

    public interface ISchoolClassEndpoint : IItemEndpoint<Org>
    {
        IListEndpoint<Enrollment> Enrollments { get; }

        IListEndpoint<User> Students { get; }

        IListEndpoint<User> Teachers { get; }
    }
}