namespace Questar.OneRoster.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Vocabulary;

    public class AcademicSessionDto : Base
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SessionType Type { get; set; }
        public GuidRefDto Parent { get; set; }
        public IEnumerable<GuidRefDto> Children { get; set; } = Enumerable.Empty<GuidRefDto>();
        public Year Year { get; set; }
    }
}