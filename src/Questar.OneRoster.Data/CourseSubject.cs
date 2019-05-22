namespace Questar.OneRoster.Data
{
    using System;

    public class CourseSubject
    {
        public CourseSubject(Subject subject) =>
            Subject = subject;

        private CourseSubject()
        {
        }

        public virtual Course Course { get; private set; }

        public virtual Guid CourseId { get; private set; }

        public virtual Subject Subject { get; private set; }

        public virtual Guid SubjectId { get; private set; }
    }
}