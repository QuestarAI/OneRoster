namespace Questar.OneRoster.Data.Profiles
{
    using Models;
    using Demographics = Data.Demographics;

    public class DemographicsProfile : BaseProfile<Demographics, Models.Demographics>
    {
        public DemographicsProfile()
        {
            CreateMap()
                .ForMember(target => target.Sex, config => config.MapFrom(source => (Gender) source.Sex));
        }
    }
}