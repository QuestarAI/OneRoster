using Questar.OneRoster.Models;

namespace Questar.OneRoster.DataServices
{
    public interface ITermRepository : IRepository<AcademicSession>
    {
        IQuery<Class> GetClassesForTerm(string academicSessionId);

        IQuery<AcademicSession> GetGradingPeriodsForTerm(string academicSessionId);
    }
}