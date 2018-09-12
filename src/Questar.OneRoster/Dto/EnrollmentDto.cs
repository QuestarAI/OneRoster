namespace Questar.OneRoster.Dto
{
    using System;
    using Common;
    using Vocabulary;

    public class EnrollmentDto : Base
    {
        public GuidRefDto User { get; set; }
        public GuidRefDto Class { get; set; }
        public GuidRefDto School { get; set; }
        public RoleType Role { get; set; }
        public bool? Primary { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}