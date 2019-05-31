namespace Questar.OneRoster.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserGrade
    {
        private UserGrade()
        {
        }

        public UserGrade(Grade grade) =>
            Grade = grade;

        public virtual User User { get; private set; }

        [Required]
        public virtual string UserId { get; private set; }

        public virtual Grade Grade { get; private set; }

        public virtual Guid GradeId { get; private set; }
    }
}