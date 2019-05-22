namespace Questar.OneRoster.Models
{
    using System.Collections.Generic;

    public class Course : Base
    {
        public string Title { get; set; }

        public GuidRef SchoolYear { get; set; }

        public string CourseCode { get; set; }

        public ICollection<Grade> Grades { get; set; }

        public ICollection<string> Subjects { get; set; }

        public GuidRef Org { get; set; }

        public ICollection<string> SubjectCodes { get; set; }

        public ICollection<GuidRef> Resources { get; set; }
    }
}