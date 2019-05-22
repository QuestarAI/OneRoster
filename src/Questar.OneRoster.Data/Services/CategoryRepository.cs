namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using DataServices;
    using Models;
    using Category = Data.Category;

    public class CategoryRepository : BaseObjectRepository<Models.Category, Category>, ICategoryRepository
    {
        public CategoryRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}