namespace Questar.OneRoster.Data.Models
{
    public class AcademicSessionFactory
    {
        public AcademicSession CreateGradingPeriod()
        {
            return new AcademicSession { Type = AcademicSessionType.GradingPeriod };
        }

        public AcademicSession CreateSchoolYear()
        {
            return new AcademicSession { Type = AcademicSessionType.SchoolYear };
        }

        public AcademicSession CreateSemester()
        {
            return new AcademicSession { Type = AcademicSessionType.Semester };
        }

        public AcademicSession CreateTerm()
        {
            return new AcademicSession { Type = AcademicSessionType.Term };
        }
    }
}