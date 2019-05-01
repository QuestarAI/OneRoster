namespace Questar.OneRoster.Client
{
    using System;

    public interface IClient : IDisposable
    {
        IAcademicSessionsEndpoint AcademicSessions { get; }

        ICategoriesEndpoint Categories { get; }

        IClassesEndpoint Classes { get; }

        ICoursesEndpoint Courses { get; }

        IGradingPeriodsEndpoint GradingPeriods { get; }

        IDemographicsEndpoint Demographics { get; }

        IEnrollmentsEndpoint Enrollments { get; }

        ILineItemsEndpoint LineItems { get; }

        IOrgsEndpoint Orgs { get; }

        IResourcesEndpoint Resources { get; }

        IResultsEndpoint Results { get; }

        ISchoolsEndpoint Schools { get; }

        IStudentsEndpoint Students { get; }

        ITeachersEndpoint Teachers { get; }

        ITermsEndpoint Terms { get; }

        IUsersEndpoint Users { get; }
    }
}
