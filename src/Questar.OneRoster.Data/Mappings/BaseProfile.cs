namespace Questar.OneRoster.Data.Mappings
{
    using AutoMapper;

    public class BaseProfile<T> : Profile where T : IBaseObject
    {
        public BaseProfile()
        {
            // TODO how does this work?
            //CreateMap<Models.Base, T>()
            //    .ForMember(source => source.Id, config => config.MapFrom(source => source.SourcedId))
            //    .ForMember(source => source.Modified, config => config.MapFrom(source => source.DateLastModified));
        }
    }
}