using System;
using Xunit;

namespace Questar.OneRoster.Data.Test
{
    using System.Linq.Expressions;
    using AutoMapper;
    using AutoMapper.Extensions.ExpressionMapping;
    using AcademicSessionDTO = Questar.OneRoster.Models.AcademicSession;

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<AcademicSession, AcademicSessionDTO>()
                    .ForMember(dto => dto.Type, conf => conf.MapFrom(ol => ol.Type));
                cfg.CreateMap<AcademicSessionDTO, AcademicSession>()
                    .ForMember(ol => ol.Title, conf => conf.MapFrom(dto => dto.Title));
            });

            IMapper mapper = new Mapper(mapperConfig);

            Expression<Func<AcademicSession, bool>> expected = bar => bar.Title.StartsWith("A");
            Expression<Func<AcademicSessionDTO, bool>> expression = dto => dto.Title.StartsWith("A");

            var actual = mapper.Map<Expression<Func<AcademicSession, bool>>>(expression);

            Assert.True(ExpressionComparer.AreEqual(expected, actual));
        }
    }
}
