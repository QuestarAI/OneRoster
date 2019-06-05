using AutoMapper;
using Questar.OneRoster.DataServices;

namespace Questar.OneRoster.Data.Services
{
    public class CategoryRepository : BaseObjectRepository<Models.Category, Category>, ICategoryRepository
    {
        public CategoryRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}