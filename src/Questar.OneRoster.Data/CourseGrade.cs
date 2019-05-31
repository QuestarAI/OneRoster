namespace Questar.OneRoster.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CourseGrade
    {
        public CourseGrade(Grade grade) =>
            Grade = grade;

        private CourseGrade()
        {
        }

        public virtual Course Course { get; private set; }

        [Required]
        public virtual string CourseId { get; private set; }

        public virtual Grade Grade { get; private set; }

        public virtual Guid GradeId { get; private set; }
    }
}