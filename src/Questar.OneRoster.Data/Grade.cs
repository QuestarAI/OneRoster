using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questar.OneRoster.Data
{
    public class Grade
    {
        public virtual int Id { get; internal set; }

        [Required] public virtual string Code { get; set; }

        public virtual IReadOnlyCollection<ClassGrade> Classes { get; } = new HashSet<ClassGrade>();

        public virtual IReadOnlyCollection<CourseGrade> Courses { get; } = new HashSet<CourseGrade>();

        public virtual IReadOnlyCollection<UserGrade> Users { get; } = new HashSet<UserGrade>();
    }
}