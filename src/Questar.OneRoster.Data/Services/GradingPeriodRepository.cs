using System.Linq;
using AutoMapper;
using Questar.OneRoster.DataServices;

namespace Questar.OneRoster.Data.Services
{
    public class GradingPeriodRepository : BaseObjectRepository<Models.AcademicSession, AcademicSession>, IGradingPeriodRepository
    {
        public GradingPeriodRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper, context.Set<AcademicSession>().Where(session => session.Type == AcademicSessionType.GradingPeriod))
        {
        }
    }
}