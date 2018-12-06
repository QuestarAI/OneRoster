namespace Questar.OneRoster.Data.Mappings
{
    using System.Linq;
    using AutoMapper;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, Models.User>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.DateLastModified, config => config.MapFrom(source => source.Modified))
                .ForMember(target => target.StatusType, config => config.MapFrom(source => source.Status))
                .ForMember(target => target.Metadata, config => config.MapFrom(source => source.MetadataCollection.Metadata))
                .ForMember(target => target.Username, config => config.MapFrom(source => source.UserName))
                .ForMember(target => target.UserIds, config => config.MapFrom(source => source.Ids))
                .ForMember(target => target.EnabledUser, config => config.MapFrom(source => source.Enabled))
                .ForMember(target => target.Role, config => config.MapFrom(source => (UserType) source.Type))
                .ForMember(target => target.Password, config => config.MapFrom(source => source.PasswordHash))
                .ForMember(target => target.Agents, config => config.MapFrom(source => source.Agents))
                .ForMember(target => target.Grades, config => config.MapFrom(source => source.Grades.Select(relationship => relationship.Grade.Code)));
        }
    }
}