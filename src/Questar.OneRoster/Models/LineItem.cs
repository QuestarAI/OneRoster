namespace Questar.OneRoster.Models
{
    using System;

    public class LineItem : Base
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime AssignDate { get; set; }

        public DateTime DueDate { get; set; }

        public GuidRef Class { get; set; }

        public GuidRef Category { get; set; }

        public GuidRef GradingPeriod { get; set; }

        public float ResultValueMin { get; set; }

        public float ResultValueMax { get; set; }
    }
}