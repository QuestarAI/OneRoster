using System.Collections.Generic;

namespace Questar.OneRoster.Models
{
    public class Class : Base
    {
        public string Title { get; set; }

        public string ClassCode { get; set; }

        public ClassType ClassType { get; set; }

        public string Location { get; set; }

        public ICollection<Grade> Grades { get; set; }

        public ICollection<string> Subjects { get; set; }

        public GuidRef Course { get; set; }

        public GuidRef School { get; set; }

        public ICollection<GuidRef> Terms { get; set; }

        public ICollection<string> SubjectCodes { get; set; }

        public ICollection<string> Periods { get; set; }

        public ICollection<GuidRef> Resources { get; set; }
    }
}