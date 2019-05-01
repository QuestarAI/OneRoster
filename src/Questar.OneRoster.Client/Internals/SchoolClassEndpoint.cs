namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class SchoolClassEndpoint : ItemEndpoint<Class>
    {
        public SchoolClassEndpoint(string path) : base(path)
        {
        }

        public SchoolClassEnrollmentsEndpoint Enrollments => new SchoolClassEnrollmentsEndpoint($"{Path}/enrollments") { Http = Http };
        public SchoolClassStudentsEndpoint Students => new SchoolClassStudentsEndpoint($"{Path}/students") { Http = Http };
        public SchoolClassTeachersEndpoint Teachers => new SchoolClassTeachersEndpoint($"{Path}/teachers") { Http = Http };
    }
}