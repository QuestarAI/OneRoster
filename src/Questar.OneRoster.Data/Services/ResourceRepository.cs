using AutoMapper;
using Questar.OneRoster.DataServices;

namespace Questar.OneRoster.Data.Services
{
    public class ResourceRepository : BaseObjectRepository<Models.Resource, Resource>, IResourceRepository
    {
        public ResourceRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}