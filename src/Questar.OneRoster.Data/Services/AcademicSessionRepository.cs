namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using DataServices;

    public class AcademicSessionRepository : BaseRepository<Models.AcademicSession, AcademicSession>, IAcademicSessionRepository
    {
        public AcademicSessionRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}