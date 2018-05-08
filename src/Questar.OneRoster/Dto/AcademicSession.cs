namespace Questar.OneRoster.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Vocabulary;

    public class AcademicSession : Base
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SessionType Type { get; set; }
        public GuidRef Parent { get; set; }
        public IEnumerable<GuidRef> Children { get; set; } = Enumerable.Empty<GuidRef>();
        public Year Year { get; set; }
    }
}