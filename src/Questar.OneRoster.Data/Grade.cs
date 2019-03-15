namespace Questar.OneRoster.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Grade
    {
        public virtual Guid Id { get; private set; }

        [Required]
        public virtual string Code { get; set; }

        public virtual IReadOnlyCollection<ClassGrade> Classes { get; } = new HashSet<ClassGrade>();

        public virtual IReadOnlyCollection<CourseGrade> Courses { get; } = new HashSet<CourseGrade>();

        public virtual IReadOnlyCollection<UserGrade> Users { get; } = new HashSet<UserGrade>();
    }
}