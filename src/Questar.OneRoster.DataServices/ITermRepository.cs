namespace Questar.OneRoster.DataServices
{
    using Models;

    public interface ITermRepository : IRepository<AcademicSession>
    {
        IQuery<Class> GetClassesForTerm(string academicSessionId);

        IQuery<AcademicSession> GetGradingPeriodsForTerm(string academicSessionId);
    }
}