using AutoMapper;
using Questar.OneRoster.DataServices;

namespace Questar.OneRoster.Data.Services
{
    public class ResultRepository : BaseObjectRepository<Models.Result, Result>, IResultRepository
    {
        public ResultRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}