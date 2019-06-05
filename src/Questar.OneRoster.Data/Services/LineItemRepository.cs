using AutoMapper;
using Questar.OneRoster.DataServices;

namespace Questar.OneRoster.Data.Services
{
    public class LineItemRepository : BaseObjectRepository<Models.LineItem, LineItem>, ILineItemRepository
    {
        public LineItemRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}