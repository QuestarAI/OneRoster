using AutoMapper;
using Questar.OneRoster.DataServices;

namespace Questar.OneRoster.Data.Services
{
    public class EnrollmentRepository : BaseObjectRepository<Models.Enrollment, Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}