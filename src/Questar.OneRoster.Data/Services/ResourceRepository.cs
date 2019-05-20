namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using DataServices;

    public class ResourceRepository : BaseRepository<Models.Resource, Resource>, IResourceRepository
    {
        public ResourceRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}