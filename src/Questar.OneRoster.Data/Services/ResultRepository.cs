namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using DataServices;
    using Models;
    using Result = Data.Result;

    public class ResultRepository : BaseObjectRepository<Models.Result, Result>, IResultRepository
    {
        public ResultRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}