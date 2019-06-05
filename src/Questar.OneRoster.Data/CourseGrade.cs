namespace Questar.OneRoster.Data
{
    public class CourseGrade
    {
        internal CourseGrade()
        {
        }

        public CourseGrade(Grade grade)
        {
            Grade = grade;
        }

        public virtual Course Course { get; internal set; }

        public virtual string CourseId { get; internal set; }

        public virtual Grade Grade { get; internal set; }

        public virtual string GradeId { get; internal set; }
    }
}