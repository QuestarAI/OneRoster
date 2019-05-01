namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Internals;
    using JetBrains.Annotations;
    
    public class OneRosterClient : IClient
    {
        [NotNull] public IFlurlClient Http { get; }

        public OneRosterClient([NotNull] IFlurlClient http)
        {
            Http = http;
        }


        public void Dispose()
        {
        }

        public IAcademicSessionsEndpoint AcademicSessions => new AcademicSessionsEndpoint("academicSessions") { Http = Http };

        public ICategoriesEndpoint Categories => new CategoriesEndpoint("categories") { Http = Http };

        public IClassesEndpoint Classes => new ClassesEndpoint("classes") { Http = Http };

        public ICoursesEndpoint Courses => new CoursesEndpoint("courses") { Http = Http };

        public IGradingPeriodsEndpoint GradingPeriods => new GradingPeriodsEndpoint("gradingPeriods") { Http = Http };

        public IDemographicsEndpoint Demographics => new DemographicsEndpoint("demographics") { Http = Http };

        public IEnrollmentsEndpoint Enrollments => new EnrollmentsEndpoint("enrollments") { Http = Http };

        public ILineItemsEndpoint LineItems => new LineItemsEndpoint("lineItems") { Http = Http };

        public IOrgsEndpoint Orgs => new OrgsEndpoint("orgs") { Http = Http };

        public IResourcesEndpoint Resources => new ResourcesEndpoint("resources") { Http = Http };

        public IResultsEndpoint Results => new ResultsEndpoint("results") { Http = Http };

        public ISchoolsEndpoint Schools => new SchoolsEndpoint("schools") { Http = Http };

        public IStudentsEndpoint Students => new StudentsEndpoint("students") { Http = Http };

        public ITeachersEndpoint Teachers => new TeachersEndpoint("teachers") { Http = Http };

        public ITermsEndpoint Terms => new TermsEndpoint("terms") { Http = Http };

        public IUsersEndpoint Users => new UsersEndpoint("users") { Http = Http };
    }
}