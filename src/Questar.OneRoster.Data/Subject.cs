using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questar.OneRoster.Data
{
    public class Subject
    {
        public virtual int Id { get; internal set; }

        [Required] public virtual string Name { get; set; }

        [Required] public virtual string Code { get; set; }

        public virtual IReadOnlyCollection<CourseSubject> Classes { get; } = new HashSet<CourseSubject>();

        public virtual IReadOnlyCollection<ClassSubject> Courses { get; } = new HashSet<ClassSubject>();
    }
}