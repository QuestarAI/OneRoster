namespace Questar.OneRoster.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Course : Base
    {
        public string Title { get; set; }
        public GuidRef SchoolYear { get; set; }
        public string CourseCode { get; set; }
        public IEnumerable<Grade> Grades { get; set; } = Enumerable.Empty<Grade>();
        public IEnumerable<string> Subjects { get; set; } = Enumerable.Empty<string>();
        public GuidRef Org { get; set; }
        public IEnumerable<SubjectCode> SubjectCodes { get; set; } = Enumerable.Empty<SubjectCode>();
        public IEnumerable<GuidRef> Resources { get; set; } = Enumerable.Empty<GuidRef>();
    }
}