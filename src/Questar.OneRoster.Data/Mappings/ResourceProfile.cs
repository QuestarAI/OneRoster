namespace Questar.OneRoster.Data.Mappings
{
    using AutoMapper;

    public class ResourceProfile : Profile
    {
        public ResourceProfile()
        {
            CreateMap<Resource, Models.Resource>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.DateLastModified, config => config.MapFrom(source => source.Modified))
                .ForMember(target => target.StatusType, config => config.MapFrom(source => source.Status))
                .ForMember(target => target.Metadata, config => config.Ignore()); // TODO don't ignore?
        }
    }
}