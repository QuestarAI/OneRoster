namespace Questar.OneRoster.Data
{
    public class ClassGrade
    {
        internal ClassGrade()
        {
        }

        public ClassGrade(Grade grade)
        {
            Grade = grade;
        }

        public virtual Class Class { get; internal set; }

        public virtual string ClassId { get; internal set; }

        public virtual Grade Grade { get; internal set; }

        public virtual string GradeId { get; internal set; }
    }
}