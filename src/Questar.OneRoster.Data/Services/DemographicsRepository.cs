using AutoMapper;
using Questar.OneRoster.DataServices;

namespace Questar.OneRoster.Data.Services
{
    public class DemographicsRepository : BaseObjectRepository<Models.Demographics, Demographics>, IDemographicsRepository
    {
        public DemographicsRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}