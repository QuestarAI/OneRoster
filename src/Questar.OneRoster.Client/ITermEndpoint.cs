namespace Questar.OneRoster.Client
{
    using Models;

    public interface ITermEndpoint : IListEndpoint<AcademicSession>
    {
        IListEndpoint<Class> Classes { get; }

        IListEndpoint<AcademicSession> GradingPeriods { get; }
    }
}