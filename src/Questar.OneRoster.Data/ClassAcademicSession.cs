namespace Questar.OneRoster.Data
{
    public class ClassAcademicSession
    {
        internal ClassAcademicSession()
        {
        }

        public ClassAcademicSession(AcademicSession academicSession)
        {
            AcademicSession = academicSession;
        }

        public virtual Class Class { get; internal set; }

        public virtual string ClassId { get; internal set; }

        public virtual AcademicSession AcademicSession { get; internal set; }

        public virtual string AcademicSessionId { get; internal set; }
    }
}