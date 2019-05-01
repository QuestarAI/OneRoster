namespace Questar.OneRoster.Client
{
    using System;
    using Flurl.Http;
    using Internals;
    using JetBrains.Annotations;
    
    public class OneRosterClient : IDisposable
    {
        [NotNull] public IFlurlClient Http { get; }

        public OneRosterClient([NotNull] IFlurlClient http)
        {
            Http = http;
        }


        public void Dispose()
        {
        }

        public AcademicSessionsEndpoint AcademicSessions => new AcademicSessionsEndpoint("academicSessions") { Http = Http };

        public CategoriesEndpoint Categories => new CategoriesEndpoint("categories") { Http = Http };

        public ClassesEndpoint Classes => new ClassesEndpoint("classes") { Http = Http };

        public CoursesEndpoint Courses => new CoursesEndpoint("courses") { Http = Http };

        public GradingPeriodsEndpoint GradingPeriods => new GradingPeriodsEndpoint("gradingPeriods") { Http = Http };

        public DemographicsEndpoint Demographics => new DemographicsEndpoint("demographics") { Http = Http };

        public EnrollmentsEndpoint Enrollments => new EnrollmentsEndpoint("enrollments") { Http = Http };

        public LineItemsEndpoint LineItems => new LineItemsEndpoint("lineItems") { Http = Http };

        public OrgsEndpoint Orgs => new OrgsEndpoint("orgs") { Http = Http };

        public ResourcesEndpoint Resources => new ResourcesEndpoint("resources") { Http = Http };

        public ResultsEndpoint Results => new ResultsEndpoint("results") { Http = Http };

        public SchoolsEndpoint Schools => new SchoolsEndpoint("schools") { Http = Http };

        public StudentsEndpoint Students => new StudentsEndpoint("students") { Http = Http };

        public TeachersEndpoint Teachers => new TeachersEndpoint("teachers") { Http = Http };

        public TermsEndpoint Terms => new TermsEndpoint("terms") { Http = Http };

        public UsersEndpoint Users => new UsersEndpoint("users") { Http = Http };
    }
}