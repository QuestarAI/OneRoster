namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class SchoolClassEndpoint : ItemEndpoint<Class>, ISchoolClassEndpoint
    {
        public SchoolClassEndpoint(string host, string path) : base(host, path)
        {
        }

        public IListEndpoint<Enrollment> Enrollments { get; }
        public IListEndpoint<User> Students { get; }
        public IListEndpoint<User> Teachers { get; }
    }
}