namespace Questar.OneRoster.Data.Mappings
{
    using AutoMapper;
    using Common;

    public class AcademicSessionProfile : Profile
    {
        public AcademicSessionProfile()
        {
            CreateMap<AcademicSession, Models.AcademicSession>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.DateLastModified, config => config.MapFrom(source => source.Modified))
                .ForMember(target => target.StatusType, config => config.MapFrom(source => source.Status))
                .ForMember(target => target.Metadata, config => config.MapFrom(source => source.MetadataCollection.Metadata))
                .ForMember(target => target.SchoolYear, config => config.MapFrom(source => (Year) (int) source.SchoolYear));
        }
    }
}