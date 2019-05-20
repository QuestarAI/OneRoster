namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using DataServices;

    public class ClassRepository : BaseRepository<Models.Class, Class>, IClassRepository
    {
        public ClassRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}