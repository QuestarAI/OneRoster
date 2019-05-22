namespace Questar.OneRoster.Data
{
    using System;

    public class ClassSubject
    {
        public ClassSubject(Subject subject) =>
            Subject = subject;

        private ClassSubject()
        {
        }

        public virtual Class Class { get; private set; }

        public virtual Guid ClassId { get; private set; }

        public virtual Subject Subject { get; private set; }

        public virtual Guid SubjectId { get; private set; }
    }
}