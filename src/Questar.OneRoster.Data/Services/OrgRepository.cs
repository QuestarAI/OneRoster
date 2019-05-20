namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using DataServices;

    public class OrgRepository : BaseRepository<Models.Org, Org>, IOrgRepository
    {
        public OrgRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}