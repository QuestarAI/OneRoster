namespace Questar.OneRoster.Data.Profiles
{
    using Models;
    using Org = Data.Org;

    public class OrgProfile : BaseProfile<Org, Models.Org>
    {
        public OrgProfile()
        {
            CreateMap()
                .ForMember(target => target.Type, config => config.MapFrom(source => (OrgType) source.Type));
        }
    }
}