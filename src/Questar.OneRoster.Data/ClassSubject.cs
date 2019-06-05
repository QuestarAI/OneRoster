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

        public virtual string ClassId { get; internal set; }

        public virtual Subject Subject { get; internal set; }

        public virtual string SubjectId { get; internal set; }
    }
}