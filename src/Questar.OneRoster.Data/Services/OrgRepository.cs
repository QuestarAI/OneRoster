namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using DataServices;
    using Models;
    using Org = Data.Org;

    public class OrgRepository : BaseRepository<Models.Org, Org>, IOrgRepository
    {
        public OrgRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}