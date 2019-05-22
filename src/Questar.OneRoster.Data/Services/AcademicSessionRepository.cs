namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using DataServices;
    using Models;
    using AcademicSession = Data.AcademicSession;

    public class AcademicSessionRepository : BaseObjectRepository<Models.AcademicSession, AcademicSession>, IAcademicSessionRepository
    {
        public AcademicSessionRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}