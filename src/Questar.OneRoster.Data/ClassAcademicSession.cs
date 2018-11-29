namespace Questar.OneRoster.Data
{
    using System;

    public class ClassAcademicSession
    {
        public ClassAcademicSession(AcademicSession academicSession)
        {
            AcademicSession = academicSession;
        }

        private ClassAcademicSession()
        {
        }

        public virtual Class Class { get; private set; }

        public virtual Guid ClassId { get; private set; }

        public virtual AcademicSession AcademicSession { get; private set; }

        public virtual Guid AcademicSessionId { get; private set; }
    }
}