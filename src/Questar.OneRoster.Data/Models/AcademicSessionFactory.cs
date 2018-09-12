namespace Questar.OneRoster.Data.Models
{
    public class AcademicSessionFactory
    {
        public AcademicSession BuildGradingPeriod() => new AcademicSession { Type = AcademicSessionType.GradingPeriod };
        public AcademicSession BuildSchoolYear() => new AcademicSession { Type = AcademicSessionType.SchoolYear };
        public AcademicSession BuildSemester() => new AcademicSession { Type = AcademicSessionType.Semester };
        public AcademicSession BuildTerm() => new AcademicSession { Type = AcademicSessionType.Term };
    }
}