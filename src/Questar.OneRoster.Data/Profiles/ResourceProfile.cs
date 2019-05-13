namespace Questar.OneRoster.Data.Profiles
{
    using System.Linq;
    using Models;
    using Resource = Data.Resource;

    public class ResourceProfile : BaseProfile<Resource, Models.Resource>
    {
        public ResourceProfile()
        {
            CreateMap()
                .ForMember(target => target.Importance, config => config.MapFrom(source => (Importance) source.Importance))
                .ForMember(target => target.Roles, config => config.MapFrom(source => source.Roles.Select(role => (RoleType) role.Role)));
        }
    }
}