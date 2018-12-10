namespace Questar.OneRoster.Data.Profiles
{
    using AutoMapper;
    using Models;
    using Resource = Data.Resource;

    public class ResourceProfile : Profile
    {
        public ResourceProfile()
        {
            CreateMap<Resource, Models.Resource>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.DateLastModified, config => config.MapFrom(source => source.Modified))
                .ForMember(target => target.StatusType, config => config.MapFrom(source => (StatusType) source.Status))
                .ForMember(target => target.Metadata, config => config.MapFrom(source => source.MetadataCollection.Metadata))
                .ForMember(target => target.Importance, config => config.MapFrom(source => (Importance) source.Importance));
        }
    }
}