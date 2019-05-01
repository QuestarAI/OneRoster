namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class SchoolClassEndpoint : ItemEndpoint<Class>, ISchoolClassEndpoint
    {
        public SchoolClassEndpoint(string path) : base(path)
        {
        }

        public IListEndpoint<Enrollment> Enrollments => new ListEndpoint<Enrollment>($"{Path}/enrollments");
        public IListEndpoint<User> Students => new ListEndpoint<User>($"{Path}/students");
        public IListEndpoint<User> Teachers => new ListEndpoint<User>($"{Path}/teachers");
    }
}