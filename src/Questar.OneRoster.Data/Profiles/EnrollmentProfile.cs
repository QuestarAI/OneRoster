using Questar.OneRoster.Models;

namespace Questar.OneRoster.Data.Profiles
{
    public class EnrollmentProfile : BaseProfile<Enrollment, Models.Enrollment>
    {
        public EnrollmentProfile()
        {
            CreateMap()
                .ForMember(target => target.Role, config => config.MapFrom(source => (RoleType) source.User.Type))
                .ForMember(target => target.School, config => config.MapFrom(source => source.Class.School));
        }
    }
}