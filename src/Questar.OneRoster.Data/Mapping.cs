namespace Questar.OneRoster.Data
{
    using AutoMapper;
    using Dto;
    using Models;

    public static class Mapping
    {
        public static IMapper BuildMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile<>();
                cfg.CreateMap<AcademicSession, AcademicSessionDto>();
            });
            return config.CreateMapper();
        }
    }
}