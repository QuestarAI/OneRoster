using System.Linq;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.Data.Profiles
{
    public class ResourceProfile : BaseProfile<Resource, Models.Resource>
    {
        public ResourceProfile()
        {
            CreateMap()
                .ForMember(target => target.Importance, config => config.MapFrom(source => (Models.Importance) source.Importance))
                .ForMember(target => target.Roles, config => config.MapFrom(source => source.Roles.Select(role => (RoleType) role.Role)));
        }
    }
}