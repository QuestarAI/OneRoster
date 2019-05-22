namespace Questar.OneRoster.Data
{
    using System;

    public class ClassGrade
    {
        public ClassGrade(Grade grade) =>
            Grade = grade;

        private ClassGrade()
        {
        }

        public virtual Class Class { get; private set; }

        public virtual Guid ClassId { get; private set; }

        public virtual Grade Grade { get; private set; }

        public virtual Guid GradeId { get; private set; }
    }
}