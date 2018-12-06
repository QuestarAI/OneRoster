namespace Questar.OneRoster.Data.Mappings
{
    using AutoMapper;

    public class OrgProfile : Profile
    {
        public OrgProfile()
        {
            CreateMap<Org, Models.Org>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.DateLastModified, config => config.MapFrom(source => source.Modified))
                .ForMember(target => target.StatusType, config => config.MapFrom(source => source.Status))
                .ForMember(target => target.Metadata, config => config.MapFrom(source => source.MetadataCollection.Metadata))
                .ForMember(target => target.Type, config => config.MapFrom(source => (OrgType) source.Type));
        }
    }
}