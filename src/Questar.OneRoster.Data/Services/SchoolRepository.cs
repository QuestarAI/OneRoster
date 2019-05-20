namespace Questar.OneRoster.Data.Services
{
    using System.Linq;
    using AutoMapper;
    using DataServices;

    public class SchoolRepository : BaseRepository<Models.Org, Org>, ISchoolRepository
    {
        public SchoolRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper, context.Set<Org>().Where(org => org.Type == OrgType.School))
        {
        }
    }
}