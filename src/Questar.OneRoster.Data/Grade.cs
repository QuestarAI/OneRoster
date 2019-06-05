using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questar.OneRoster.Data
{
    public class Grade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] [MaxLength(10)] public virtual string Id { get; internal set; }

        [Required] public virtual string Code { get; set; }

        public virtual IReadOnlyCollection<ClassGrade> Classes { get; } = new HashSet<ClassGrade>();

        public virtual IReadOnlyCollection<CourseGrade> Courses { get; } = new HashSet<CourseGrade>();

        public virtual IReadOnlyCollection<UserGrade> Users { get; } = new HashSet<UserGrade>();
    }
}