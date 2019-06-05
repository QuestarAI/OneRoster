using System;
using System.Collections.Generic;
using System.Linq;

namespace Questar.OneRoster.Models
{
    public class AcademicSession : Base
    {
        public string Title { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public AcademicSessionType Type { get; set; }

        public GuidRef Parent { get; set; }

        public IEnumerable<GuidRef> Children { get; set; } = Enumerable.Empty<GuidRef>();

        public int SchoolYear { get; set; }
    }
}