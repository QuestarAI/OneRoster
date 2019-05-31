namespace Questar.OneRoster.Data
{
    using System.ComponentModel.DataAnnotations;

    public class ClassAcademicSession
    {
        public ClassAcademicSession(AcademicSession academicSession) =>
            AcademicSession = academicSession;

        private ClassAcademicSession()
        {
        }

        public virtual Class Class { get; private set; }

        [Required]
        public virtual string ClassId { get; private set; }

        public virtual AcademicSession AcademicSession { get; private set; }

        [Required]
        public virtual string AcademicSessionId { get; private set; }
    }
}