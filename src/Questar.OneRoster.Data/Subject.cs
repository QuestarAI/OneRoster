namespace Questar.OneRoster.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Subject
    {
        public virtual Guid Id { get; private set; }

        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual string Code { get; set; }

        public virtual IReadOnlyCollection<CourseSubject> Classes { get; } = new HashSet<CourseSubject>();
        
        public virtual IReadOnlyCollection<ClassSubject> Courses { get; } = new HashSet<ClassSubject>();
    }
}