namespace Questar.OneRoster.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ClassGrade
    {
        public ClassGrade(Grade grade) =>
            Grade = grade;

        private ClassGrade()
        {
        }

        public virtual Class Class { get; private set; }

        [Required]
        public virtual string ClassId { get; private set; }

        public virtual Grade Grade { get; private set; }

        public virtual Guid GradeId { get; private set; }
    }
}