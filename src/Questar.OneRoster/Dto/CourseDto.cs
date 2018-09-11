namespace Questar.OneRoster.Dto
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Vocabulary.Ceds;
    using Vocabulary.Sced;

    public class CourseDto<TGrade, TSubjectCode> : Base
    {
        public string Title { get; set; }
        public GuidRef SchoolYear { get; set; }
        public string CourseCode { get; set; }
        public IEnumerable<TGrade> Grades { get; set; } = Enumerable.Empty<TGrade>();
        public IEnumerable<string> Subjects { get; set; } = Enumerable.Empty<string>();
        public GuidRef Org { get; set; }
        public IEnumerable<TSubjectCode> SubjectCodes { get; set; } = Enumerable.Empty<TSubjectCode>();
        public IEnumerable<GuidRef> Resources { get; set; } = Enumerable.Empty<GuidRef>();
    }

    public class CourseDto : CourseDto<Grade, SubjectCode> { }
}