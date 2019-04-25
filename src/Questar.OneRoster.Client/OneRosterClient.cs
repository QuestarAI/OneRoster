namespace Questar.OneRoster.Client
{
    using System;
    using System.Net.Http;
    using Flurl.Http;
    using JetBrains.Annotations;

    public class OneRosterClient : IClient
    {
        public OneRosterClient([NotNull] IFlurlClient http) => Http = http;

        public OneRosterClient([NotNull] HttpClient http)
            : this(new FlurlClient(http))
        {
        }

        public IFlurlClient Http { get; }

        public void Dispose() => Http.Dispose();

        public IAcademicSessionsEndpoint AcademicSessions => throw new NotImplementedException();

        public ICategoriesEndpoint Categories => throw new NotImplementedException();

        public IClassesEndpoint Classes => throw new NotImplementedException();

        public ICourseEndpoint Courses => throw new NotImplementedException();

        public IGradingPeriodsEndpoint GradingPeriods => throw new NotImplementedException();

        public IDemographicsEndpoint Demographics => throw new NotImplementedException();

        public IEnrollmentsEndpoint Enrollments => throw new NotImplementedException();

        public ILineItemsEndpoint LineItems => throw new NotImplementedException();

        public IOrgsEndpoint Orgs => throw new NotImplementedException();

        public IResourcesEndpoint Resources => throw new NotImplementedException();

        public IResultsEndpoint Results => throw new NotImplementedException();

        public ISchoolsEndpoint Schools => throw new NotImplementedException();

        public IStudentsEndpoint Students => throw new NotImplementedException();

        public ITeachersEndpoint Teachers => throw new NotImplementedException();

        public ITermsEndpoint Terms => throw new NotImplementedException();

        public IUsersEndpoint Users => throw new NotImplementedException();
    }
}