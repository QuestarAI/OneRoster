namespace Questar.OneRoster.Data.Profiles
{
    public class DemographicsProfile : BaseProfile<Demographics, Models.Demographics>
    {
        public DemographicsProfile()
        {
            CreateMap()
                .ForMember(target => target.Sex, config => config.MapFrom(source => (Models.Gender) source.Sex));
        }
    }
}