namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.Extensions.ExpressionMapping;
    using DataServices;
    using DataServices.EntityFrameworkCore;

    public class TermRepository : BaseRepository<Models.AcademicSession, AcademicSession>, ITermRepository
    {
        public TermRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper, context.Set<AcademicSession>().Where(session => session.Type == AcademicSessionType.Term))
        {
        }

        public IQuery<Models.Class> GetClassesForTerm(string academicSessionId)
        {
            var source =
                Context.Classes
                    .Where(@class => @class.Terms.Select(term => term.AcademicSessionId).Contains(Guid.Parse(academicSessionId)))
                    .UseAsDataSource(Mapper)
                    .For<Models.Class>();
            return new SourceInjectedQuery<Models.Class>(source, model => model.SourcedId, (x, y) => (string) x == (string) y);
        }

        public IQuery<Models.AcademicSession> GetGradingPeriodsForTerm(string academicSessionId)
        {
            var source =
                Context.AcademicSessions
                    .Where(session => session.ParentId == Guid.Parse(academicSessionId))
                    .UseAsDataSource(Mapper)
                    .For<Models.AcademicSession>();
            return new SourceInjectedQuery<Models.AcademicSession>(source, model => model.SourcedId, (x, y) => (string) x == (string) y);
        }
    }
}