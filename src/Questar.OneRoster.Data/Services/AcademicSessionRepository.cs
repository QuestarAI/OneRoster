using AutoMapper;
using Questar.OneRoster.DataServices;

namespace Questar.OneRoster.Data.Services
{
    public class AcademicSessionRepository : BaseObjectRepository<Models.AcademicSession, AcademicSession>, IAcademicSessionRepository
    {
        public AcademicSessionRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}