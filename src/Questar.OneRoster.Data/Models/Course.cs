namespace Questar.OneRoster.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course : IBaseObject, IValidatableObject
    {
        public virtual Guid CourseId { get; private set; }

        [Required]
        [MaxLength(256)]
        public virtual string Title { get; set; }

        [Required]
        [MaxLength(256)]
        public virtual string Code { get; set; }

        public virtual AcademicSession SchoolYear { get; set; }

        public virtual Guid SchoolYearId { get; private set; }

        public virtual Organization Organization { get; set; }

        public virtual Guid OrganizationId { get; private set; }

        public virtual ISet<Class> Classes { get; } = new HashSet<Class>();

        public virtual ISet<CourseResource> Resources { get; } = new HashSet<CourseResource>();

        public virtual Status Status { get; set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual DateTimeOffset Modified { get; private set; }

        // TODO subjects, subject codes

        // TODO grades

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}