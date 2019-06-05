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

        public virtual int ClassId { get; internal set; }

        public virtual AcademicSession AcademicSession { get; internal set; }

        public virtual int AcademicSessionId { get; internal set; }
    }
}