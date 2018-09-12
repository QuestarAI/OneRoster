namespace Questar.OneRoster.Dto
{
    using System;
    using Common;

    public class LineItemDto : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime DueDate { get; set; }
        public GuidRefDto Class { get; set; }
        public GuidRefDto Category { get; set; }
        public GuidRefDto GradingPeriod { get; set; }
        public double ResultValueMin { get; set; }
        public double ResultValueMax { get; set; }
    }
}