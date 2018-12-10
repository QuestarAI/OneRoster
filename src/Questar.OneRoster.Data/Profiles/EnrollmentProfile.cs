namespace Questar.OneRoster.Data.Profiles
{
    using AutoMapper;
    using Models;

    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Data.Enrollment, Enrollment>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.DateLastModified, config => config.MapFrom(source => source.Modified))
                .ForMember(target => target.StatusType, config => config.MapFrom(source => (StatusType) source.Status))
                .ForMember(target => target.Metadata, config => config.MapFrom(source => source.MetadataCollection.Metadata))
                .ForMember(target => target.Role, config => config.MapFrom(source => (RoleType) source.User.Type))
                .ForMember(target => target.School, config => config.MapFrom(source => source.Class.School));
        }
    }
}