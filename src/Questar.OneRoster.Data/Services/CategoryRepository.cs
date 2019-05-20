namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using DataServices;

    public class CategoryRepository : BaseRepository<Models.Category, Category>, ICategoryRepository
    {
        public CategoryRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}