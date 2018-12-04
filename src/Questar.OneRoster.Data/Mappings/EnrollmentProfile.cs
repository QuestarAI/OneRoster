namespace Questar.OneRoster.Data.Mappings
{
    public class EnrollmentProfile : BaseProfile<Enrollment>
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, Models.Enrollment>();
        }
    }
}