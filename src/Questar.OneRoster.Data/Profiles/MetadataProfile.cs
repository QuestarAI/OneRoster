using AutoMapper;

namespace Questar.OneRoster.Data.Profiles
{
    public class MetadataProfile : Profile
    {
        public MetadataProfile()
        {
            CreateMap<Metadata, Models.Metadata>();
        }
    }
}