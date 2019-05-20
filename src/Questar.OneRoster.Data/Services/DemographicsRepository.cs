namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using DataServices;

    public class DemographicsRepository : BaseRepository<Models.Demographics, Demographics>, IDemographicsRepository
    {
        public DemographicsRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}