namespace Questar.OneRoster.Data
{
    public class ClassSubject
    {
        internal ClassSubject()
        {
        }

        public ClassSubject(Subject subject)
        {
            Subject = subject;
        }

        public virtual Class Class { get; internal set; }

        public virtual int ClassId { get; internal set; }

        public virtual Subject Subject { get; internal set; }

        public virtual int SubjectId { get; internal set; }
    }
}