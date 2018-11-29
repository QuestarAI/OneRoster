namespace Questar.OneRoster.Data
{
    using System;

    public class CourseGrade
    {
        public CourseGrade(Grade grade)
        {
            Grade = grade;
        }

        private CourseGrade()
        {
        }

        public virtual Course Course { get; private set; }

        public virtual Guid CourseId { get; private set; }

        public virtual Grade Grade { get; private set; }

        public virtual Guid GradeId { get; private set; }
    }
}