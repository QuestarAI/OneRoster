namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using DataServices;

    public class ResultRepository : BaseRepository<Models.Result, Result>, IResultRepository
    {
        public ResultRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}