namespace Questar.OneRoster.Data.Profiles
{
    using Models;
    using AcademicSession = Data.AcademicSession;

    public class AcademicSessionProfile : BaseProfile<AcademicSession, Models.AcademicSession>
    {
        public AcademicSessionProfile()
        {
            CreateMap()
                .ForMember(target => target.SchoolYear, config => config.MapFrom(source => (int) source.SchoolYear))
                .ForMember(target => target.Type, config => config.MapFrom(source => (AcademicSessionType) source.Type));
        }
    }
}