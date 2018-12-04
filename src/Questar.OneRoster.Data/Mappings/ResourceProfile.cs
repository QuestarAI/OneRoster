namespace Questar.OneRoster.Data.Mappings
{
    public class ResourceProfile : BaseProfile<Resource>
    {
        public ResourceProfile()
        {
            CreateMap<Resource, Models.Resource>();
        }
    }
}