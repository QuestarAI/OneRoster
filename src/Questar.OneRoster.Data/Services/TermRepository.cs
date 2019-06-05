using System.Linq;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.DataServices.EntityFrameworkCore;

namespace Questar.OneRoster.Data.Services
{
    public class TermRepository : BaseObjectRepository<Models.AcademicSession, AcademicSession>, ITermRepository
    {
        public TermRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper, context.Set<AcademicSession>().Where(session => session.Type == AcademicSessionType.Term))
        {
        }

        public IQuery<Models.Class> GetClassesForTerm(string academicSessionId)
        {
            return Context.Classes
                .Where(@class => @class.Terms.Any(term => term.AcademicSessionId == academicSessionId))
                .UseAsDataSource(Mapper)
                .For<Models.Class>()
                .ToBaseQuery();
        }


        public IQuery<Models.AcademicSession> GetGradingPeriodsForTerm(string academicSessionId)
        {
            return Context.AcademicSessions
                .Where(session => session.ParentId == academicSessionId)
                .UseAsDataSource(Mapper)
                .For<Models.AcademicSession>()
                .ToBaseQuery();
        }
    }
}