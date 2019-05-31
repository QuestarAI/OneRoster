namespace Questar.OneRoster.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ClassPeriod
    {
        public ClassPeriod(string period) =>
            Period = period;

        private ClassPeriod()
        {
        }

        public virtual Class Class { get; private set; }

        [Required]
        public virtual string ClassId { get; private set; }

        [Required]
        public virtual string Period { get; private set; }
    }
}