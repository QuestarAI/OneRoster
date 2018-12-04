namespace Questar.OneRoster.Data.Mappings
{
    using AutoMapper;

    public class BaseProfile<T> : Profile where T : IBaseObject
    {
        public BaseProfile()
        {
            CreateMap<T, Models.Base>();
        }
    }
}