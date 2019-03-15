namespace Questar.OneRoster.Data.Profiles
{
    using AutoMapper;
    using Models;
    using Category = Data.Category;

    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, Models.Category>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.DateLastModified, config => config.MapFrom(source => source.Modified))
                .ForMember(target => target.StatusType, config => config.MapFrom(source => (StatusType) source.Status))
                .ForMember(target => target.Metadata, config => config.MapFrom(source => source.MetadataCollection.Metadata));
        }
    }
}