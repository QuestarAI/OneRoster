namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class SchoolEndpoint : ItemEndpoint<Org>, ISchoolEndpoint
    {
        public SchoolEndpoint(string path) : base(path)
        {
        }

        public IListEndpoint<Course> Courses => new ListEndpoint<Course>($"{Path}/courses");
        public ISchoolClassesEndpoint Classes => new SchoolClassesEndpoint($"{Path}/classes");
        public IListEndpoint<Enrollment> Enrollments => new ListEndpoint<Enrollment>($"{Path}/enrollments");
        public IListEndpoint<User> Students => new ListEndpoint<User>($"{Path}/students");
        public IListEndpoint<User> Teachers => new ListEndpoint<User>($"{Path}/teachers");
        public IListEndpoint<AcademicSession> Terms => new ListEndpoint<AcademicSession>($"{Path}/terms");
    }
}