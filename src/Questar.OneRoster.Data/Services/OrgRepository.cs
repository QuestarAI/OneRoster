using AutoMapper;
using Questar.OneRoster.DataServices;

namespace Questar.OneRoster.Data.Services
{
    public class OrgRepository : BaseObjectRepository<Models.Org, Org>, IOrgRepository
    {
        public OrgRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}