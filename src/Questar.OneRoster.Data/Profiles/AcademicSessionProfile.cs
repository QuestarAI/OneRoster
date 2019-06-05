namespace Questar.OneRoster.Data.Profiles
{
    public class AcademicSessionProfile : BaseProfile<AcademicSession, Models.AcademicSession>
    {
        public AcademicSessionProfile()
        {
            CreateMap()
                .ForMember(target => target.SchoolYear, config => config.MapFrom(source => (int) source.SchoolYear))
                .ForMember(target => target.Type, config => config.MapFrom(source => (Models.AcademicSessionType) source.Type));
        }
    }
}