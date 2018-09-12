namespace Questar.OneRoster.Dto
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Vocabulary;
    using Vocabulary.Ceds;
    using Vocabulary.Sced;

    public class ClassDto<TGrade, TSubjectCode> : Base
    {
        public string Title { get; set; }
        public string ClassCode { get; set; }
        public ClassType ClassType { get; set; }
        public string Location { get; set; }
        public IEnumerable<TGrade> Grades { get; set; } = Enumerable.Empty<TGrade>();
        public IEnumerable<string> Subjects { get; set; } = Enumerable.Empty<string>();
        public GuidRefDto Course { get; set; }
        public GuidRefDto School { get; set; }
        public GuidRefDto Terms { get; set; }
        public IEnumerable<TSubjectCode> SubjectCodes { get; set; } = Enumerable.Empty<TSubjectCode>();
        public IEnumerable<string> Periods { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<GuidRefDto> Resources { get; set; } = Enumerable.Empty<GuidRefDto>();
    }

    public class ClassDto : ClassDto<Grade, SubjectCode> { }
}