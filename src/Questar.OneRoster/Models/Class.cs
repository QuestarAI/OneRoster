namespace Questar.OneRoster.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Vocabulary;
    using Vocabulary.Ceds;
    using Vocabulary.Sced;

    public class Class : Base
    {
        public string Title { get; set; }
        public string ClassCode { get; set; }
        public ClassType ClassType { get; set; }
        public string Location { get; set; }
        public IEnumerable<Grade> Grades { get; set; } = Enumerable.Empty<Grade>();
        public IEnumerable<string> Subjects { get; set; } = Enumerable.Empty<string>();
        public GuidRef Course { get; set; }
        public GuidRef School { get; set; }
        public GuidRef Terms { get; set; }
        public IEnumerable<SubjectCode> SubjectCodes { get; set; } = Enumerable.Empty<SubjectCode>();
        public IEnumerable<string> Periods { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<GuidRef> Resources { get; set; } = Enumerable.Empty<GuidRef>();
    }
}