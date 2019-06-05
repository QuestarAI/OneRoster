namespace Questar.OneRoster.Data
{
    public class CourseSubject
    {
        internal CourseSubject()
        {
        }

        public CourseSubject(Subject subject)
        {
            Subject = subject;
        }

        public virtual Course Course { get; internal set; }

        public virtual int CourseId { get; internal set; }

        public virtual Subject Subject { get; internal set; }

        public virtual int SubjectId { get; internal set; }
    }
}