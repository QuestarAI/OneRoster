namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using DataServices;

    public class EnrollmentRepository : BaseRepository<Models.Enrollment, Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}