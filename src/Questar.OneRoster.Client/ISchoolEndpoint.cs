namespace Questar.OneRoster.Client
{
    using Models;

    public interface ISchoolEndpoint : IItemEndpoint<Org>
    {
        IListEndpoint<Course> Courses { get; }

        ISchoolClassesEndpoint Classes { get; }

        IListEndpoint<Enrollment> Enrollments { get; }

        IListEndpoint<User> Students { get; }

        IListEndpoint<User> Teachers { get; }

        IListEndpoint<AcademicSession> Terms { get; }
    }
}