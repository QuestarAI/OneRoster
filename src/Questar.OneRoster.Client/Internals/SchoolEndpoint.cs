namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class SchoolEndpoint : ItemEndpoint<Org>
    {
        public SchoolEndpoint(string path) : base(path)
        {
        }

        public SchoolCoursesEndpoint Courses => new SchoolCoursesEndpoint($"{Path}/courses") { Http = Http };
        public SchoolClassesEndpoint Classes => new SchoolClassesEndpoint($"{Path}/classes") { Http = Http };
        public SchoolEnrollmentsEndpoint Enrollments => new SchoolEnrollmentsEndpoint($"{Path}/enrollments") { Http = Http };
        public SchoolStudentsEndpoint Students => new SchoolStudentsEndpoint($"{Path}/students") { Http = Http };
        public SchoolTeachersEndpoint Teachers => new SchoolTeachersEndpoint($"{Path}/teachers") { Http = Http };
        public SchoolTermsEndpoint Terms => new SchoolTermsEndpoint($"{Path}/terms") { Http = Http };
    }
}