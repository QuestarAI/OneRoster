namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class SchoolEndpoint : ItemEndpoint<Org>
    {
        public SchoolEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public SchoolCoursesEndpoint Courses => new SchoolCoursesEndpoint(Http, $"{Path}/courses");
        public SchoolClassesEndpoint Classes => new SchoolClassesEndpoint(Http, $"{Path}/classes");
        public SchoolEnrollmentsEndpoint Enrollments => new SchoolEnrollmentsEndpoint(Http, $"{Path}/enrollments");
        public SchoolStudentsEndpoint Students => new SchoolStudentsEndpoint(Http, $"{Path}/students");
        public SchoolTeachersEndpoint Teachers => new SchoolTeachersEndpoint(Http, $"{Path}/teachers");
        public SchoolTermsEndpoint Terms => new SchoolTermsEndpoint(Http, $"{Path}/terms");
    }
}