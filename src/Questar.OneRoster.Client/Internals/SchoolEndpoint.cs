namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class SchoolEndpoint : ItemEndpoint<Org>, ISchoolEndpoint
    {
        public SchoolEndpoint(string host, string path) : base(host, path)
        {
        }

        public IListEndpoint<Course> Courses { get; }
        public ISchoolClassesEndpoint Classes { get; }
        public IListEndpoint<Enrollment> Enrollments { get; }
        public IListEndpoint<User> Students { get; }
        public IListEndpoint<User> Teachers { get; }
        public IListEndpoint<AcademicSession> Terms { get; }
    }
}