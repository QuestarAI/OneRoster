namespace Questar.OneRoster.Data.Mappings
{
    public class AcademicSessionProfile : BaseProfile<AcademicSession>
    {
        public AcademicSessionProfile()
        {
            CreateMap<AcademicSession, Models.AcademicSession>();
        }
    }
}