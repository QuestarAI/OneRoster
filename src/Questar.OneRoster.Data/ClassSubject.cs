namespace Questar.OneRoster.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ClassSubject
    {
        public ClassSubject(Subject subject) =>
            Subject = subject;

        private ClassSubject()
        {
        }

        public virtual Class Class { get; private set; }

        [Required]
        public virtual string ClassId { get; private set; }

        public virtual Subject Subject { get; private set; }

        public virtual Guid SubjectId { get; private set; }
    }
}