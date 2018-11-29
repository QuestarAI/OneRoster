namespace Questar.OneRoster.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ClassPeriod
    {
        public ClassPeriod(byte period)
        {
            Period = period;
        }

        private ClassPeriod()
        {
        }

        public virtual Class Class { get; private set; }

        public virtual Guid ClassId { get; private set; }

        [Required]
        public virtual byte Period { get; private set; }
    }
}