namespace Questar.OneRoster.Data.Mappings
{
    public class CategoryProfile : BaseProfile<Category>
    {
        public CategoryProfile()
        {
            CreateMap<Category, Models.Category>();
        }
    }
}