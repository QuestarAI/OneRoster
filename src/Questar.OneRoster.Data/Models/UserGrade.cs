namespace Questar.OneRoster.Data.Models
{
    using System;

    public class UserGrade
    {
        private UserGrade()
        {
        }

        public UserGrade(Grade grade)
        {
            Grade = grade;
        }

        public virtual User User { get; private set; }

        public virtual Guid UserId { get; private set; }

        public virtual Grade Grade { get; private set; }

        public virtual Guid GradeId { get; private set; }
    }
}