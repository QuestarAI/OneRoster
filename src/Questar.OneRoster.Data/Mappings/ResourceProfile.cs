namespace Questar.OneRoster.Data.Mappings
{
    public class ResourceProfile : BaseProfile<Resource>
    {
        public ResourceProfile()
        {
            CreateMap<Resource, Models.Resource>()
                .ForMember(source => source.SourcedId, config => config.MapFrom(target => target.Id))
                .ForMember(source => source.DateLastModified, config => config.MapFrom(target => target.Modified))
                .ForMember(source => source.StatusType, config => config.MapFrom(source => source.Status))
                .ForMember(source => source.Metadata, config => config.Ignore()); // TODO don't ignore?
        }
    }
}