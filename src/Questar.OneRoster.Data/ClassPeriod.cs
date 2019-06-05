using System.ComponentModel.DataAnnotations;

namespace Questar.OneRoster.Data
{
    public class ClassPeriod
    {
        internal ClassPeriod()
        {
        }

        public ClassPeriod(string period)
        {
            Period = period;
        }

        public virtual Class Class { get; internal set; }

        public virtual string ClassId { get; internal set; }

        [Required] public virtual string Period { get; internal set; }
    }
}