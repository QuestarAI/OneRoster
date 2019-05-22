namespace Questar.OneRoster.Client.Services
{
    using System;
    using Flurl.Http;
    using JetBrains.Annotations;

    public class OneRosterClient : IDisposable
    {
        public OneRosterClient([NotNull] IFlurlClient http)
        {
            Http = http;
            Path = "/ims/oneroster/v1p1";
        }

        public IFlurlClient Http { get; }

        public string Path { get; }

        public AcademicSessionsEndpoint AcademicSessions => new AcademicSessionsEndpoint(Http, $"{Path}/academicSessions");

        public CategoriesEndpoint Categories => new CategoriesEndpoint(Http, $"{Path}/categories");

        public ClassesEndpoint Classes => new ClassesEndpoint(Http, $"{Path}/classes");

        public CoursesEndpoint Courses => new CoursesEndpoint(Http, $"{Path}/courses");

        public GradingPeriodsEndpoint GradingPeriods => new GradingPeriodsEndpoint(Http, $"{Path}/gradingPeriods");

        public DemographicsEndpoint Demographics => new DemographicsEndpoint(Http, $"{Path}/demographics");

        public EnrollmentsEndpoint Enrollments => new EnrollmentsEndpoint(Http, $"{Path}/enrollments");

        public LineItemsEndpoint LineItems => new LineItemsEndpoint(Http, $"{Path}/lineItems");

        public OrgsEndpoint Orgs => new OrgsEndpoint(Http, $"{Path}/orgs");

        public ResourcesEndpoint Resources => new ResourcesEndpoint(Http, $"{Path}/resources");

        public ResultsEndpoint Results => new ResultsEndpoint(Http, $"{Path}/results");

        public SchoolsEndpoint Schools => new SchoolsEndpoint(Http, $"{Path}/schools");

        public StudentsEndpoint Students => new StudentsEndpoint(Http, $"{Path}/students");

        public TeachersEndpoint Teachers => new TeachersEndpoint(Http, $"{Path}/teachers");

        public TermsEndpoint Terms => new TermsEndpoint(Http, $"{Path}/terms");

        public UsersEndpoint Users => new UsersEndpoint(Http, $"{Path}/users");


        public void Dispose()
        {
        }
    }
}