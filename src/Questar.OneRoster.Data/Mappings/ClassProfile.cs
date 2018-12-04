namespace Questar.OneRoster.Data.Mappings
{
    public class ClassProfile : BaseProfile<Class>
    {
        public ClassProfile()
        {
            CreateMap<Class, Models.Class>();
        }
    }
}