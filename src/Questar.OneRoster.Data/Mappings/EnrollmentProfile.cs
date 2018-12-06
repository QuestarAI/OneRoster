namespace Questar.OneRoster.Data.Mappings
{
    using AutoMapper;

    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, Models.Enrollment>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.DateLastModified, config => config.MapFrom(source => source.Modified))
                .ForMember(target => target.StatusType, config => config.MapFrom(source => source.Status))
                .ForMember(target => target.Metadata, config => config.MapFrom(source => source.MetadataCollection.Metadata))
                .ForMember(target => target.Role, config => config.MapFrom(source => (UserType) source.User.Type))
                .ForMember(target => target.School, config => config.MapFrom(source => source.Class.School));
        }
    }
}