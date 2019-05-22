namespace Questar.OneRoster.Data.Profiles
{
    using AutoMapper;
    using Models;

    public abstract class BaseProfile<TSource, TTarget> : Profile
        where TSource : IBaseObject
        where TTarget : Base
    {
        protected IMappingExpression<TSource, TTarget> CreateMap()
        {
            return
                CreateMap<TSource, TTarget>()
                    .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id.ToString()))
                    .ForMember(target => target.DateLastModified, config => config.MapFrom(source => source.Modified))
                    .ForMember(target => target.StatusType, config => config.MapFrom(source => (StatusType) source.Status))
                    .ForMember(target => target.Metadata, config => config.MapFrom(source => source.MetadataCollection.Metadata));
        }
    }
}