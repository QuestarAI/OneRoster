namespace Questar.OneRoster.Models
{
    using System;
    using Common;
    using Vocabulary;

    public class Enrollment : Base
    {
        public GuidRef User { get; set; }
        public GuidRef Class { get; set; }
        public GuidRef School { get; set; }
        public RoleType Role { get; set; }
        public bool? Primary { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}