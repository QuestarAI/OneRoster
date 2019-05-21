namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using DataServices;
    using Models;
    using LineItem = Data.LineItem;

    public class LineItemRepository : BaseRepository<Models.LineItem, LineItem>, ILineItemRepository
    {
        public LineItemRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}