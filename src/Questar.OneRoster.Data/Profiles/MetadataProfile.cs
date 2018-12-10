namespace Questar.OneRoster.Data.Profiles
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