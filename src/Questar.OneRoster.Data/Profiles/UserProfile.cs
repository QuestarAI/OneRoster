namespace Questar.OneRoster.Data.Profiles
{
    using System.Linq;
    using Models;
    using User = Data.User;

    public class UserProfile : BaseProfile<User, Models.User>
    {
        public UserProfile()
        {
            CreateMap()
                .ForMember(target => target.Username, config => config.MapFrom(source => source.UserName))
                .ForMember(target => target.UserIds, config => config.MapFrom(source => source.Ids))
                .ForMember(target => target.EnabledUser, config => config.MapFrom(source => source.Enabled))
                .ForMember(target => target.Role, config => config.MapFrom(source => (RoleType) source.Type))
                .ForMember(target => target.Password, config => config.MapFrom(source => source.PasswordHash))
                .ForMember(target => target.Agents, config => config.MapFrom(source => source.Agents))
                .ForMember(target => target.Grades, config => config.MapFrom(source => source.Grades.Select(relationship => relationship.Grade.Code)));
        }
    }
}