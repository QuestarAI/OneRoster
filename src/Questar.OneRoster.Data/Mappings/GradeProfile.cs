namespace Questar.OneRoster.Data.Mappings
{
    using AutoMapper;

    public class GradeProfile : Profile
    {
        public GradeProfile()
        {
            CreateMap<Grade, string>()
                .ConvertUsing(source => source.Code);
        }
    }
}