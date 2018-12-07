namespace Questar.OneRoster.Data.Mappings
{
    using AutoMapper;
    using Models;

    public class DemographicsProfile : Profile
    {
        public DemographicsProfile()
        {
            CreateMap<Data.Demographics, Demographics>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.DateLastModified, config => config.MapFrom(source => source.Modified))
                .ForMember(target => target.StatusType, config => config.MapFrom(source => (StatusType) source.Status))
                .ForMember(target => target.Metadata, config => config.MapFrom(source => source.MetadataCollection.Metadata))
                .ForMember(target => target.Sex, config => config.MapFrom(source => (Gender) source.Sex));
        }
    }
}