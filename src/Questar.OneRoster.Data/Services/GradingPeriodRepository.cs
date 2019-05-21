namespace Questar.OneRoster.Data.Services
{
    using System.Linq;
    using AutoMapper;
    using DataServices;
    using Models;
    using AcademicSession = Data.AcademicSession;
    using AcademicSessionType = Data.AcademicSessionType;

    public class GradingPeriodRepository : BaseRepository<Models.AcademicSession, AcademicSession>, IGradingPeriodRepository
    {
        public GradingPeriodRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper, context.Set<AcademicSession>().Where(session => session.Type == AcademicSessionType.GradingPeriod))
        {
        }
    }
}