namespace Questar.OneRoster.Data.Profiles
{
    using AutoMapper;
    using Models;
    using AcademicSession = Data.AcademicSession;

    public class AcademicSessionProfile : Profile
    {
        public AcademicSessionProfile()
        {
            CreateMap<AcademicSession, Models.AcademicSession>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.DateLastModified, config => config.MapFrom(source => source.Modified))
                .ForMember(target => target.StatusType, config => config.MapFrom(source => (StatusType) source.Status))
                .ForMember(target => target.Metadata, config => config.MapFrom(source => source.MetadataCollection.Metadata))
                .ForMember(target => target.SchoolYear, config => config.MapFrom(source => (int) source.SchoolYear))
                .ForMember(target => target.Type, config => config.MapFrom(source => (AcademicSessionType) source.Type));
        }
    }
}