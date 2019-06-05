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

        public virtual int ClassId { get; internal set; }

        public virtual Grade Grade { get; internal set; }

        public virtual int GradeId { get; internal set; }
    }
}