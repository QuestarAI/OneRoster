namespace Questar.OneRoster.Data.Mappings
{
    using AutoMapper;

    public class MetadataProfile : Profile
    {
        public MetadataProfile()
        {
            CreateMap<Metadata, Models.Metadata>();
        }
    }
}