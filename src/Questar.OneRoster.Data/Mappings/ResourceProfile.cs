namespace Questar.OneRoster.Data.Mappings
{
    public class ResourceProfile : BaseProfile<Resource>
    {
        public ResourceProfile()
        {
            CreateMap<Models.Resource, Resource>()
                .ForMember(source => source.Id, config => config.MapFrom(target => target.SourcedId))
                .ForMember(source => source.Modified, config => config.MapFrom(target => target.DateLastModified))
                .ForMember(source => source.Status, config => config.MapFrom(source => source.StatusType))
                .ForMember(source => source.MetadataCollection, config => config.Ignore()); // TODO don't ignore?

            CreateMap<Resource, Models.Resource>()
                .ForMember(source => source.SourcedId, config => config.MapFrom(target => target.Id))
                .ForMember(source => source.DateLastModified, config => config.MapFrom(target => target.Modified))
                .ForMember(source => source.StatusType, config => config.MapFrom(source => source.Status))
                .ForMember(source => source.Metadata, config => config.Ignore()); // TODO don't ignore?
        }
    }
}