namespace Questar.OneRoster.Data.Mappings
{
    public class DemographicsProfile : BaseProfile<Demographics>
    {
        public DemographicsProfile()
        {
            CreateMap<Demographics, Models.Demographics>();
        }
    }
}