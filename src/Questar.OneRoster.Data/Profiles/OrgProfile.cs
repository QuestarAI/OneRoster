namespace Questar.OneRoster.Data.Profiles
{
    public class OrgProfile : BaseProfile<Org, Models.Org>
    {
        public OrgProfile()
        {
            CreateMap()
                .ForMember(target => target.Type, config => config.MapFrom(source => (Models.OrgType) source.Type));
        }
    }
}