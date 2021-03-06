namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using DataServices;
    using Models;
    using Resource = Data.Resource;

    public class ResourceRepository : BaseObjectRepository<Models.Resource, Resource>, IResourceRepository
    {
        public ResourceRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}