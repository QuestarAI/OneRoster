namespace Questar.OneRoster.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Class : IBaseObject, IValidatableObject
    {
        public virtual Guid ClassId { get; private set; }

        [Required]
        [MaxLength(64)]
        public virtual string Title { get; set; }

        [Required]
        [MaxLength(64)]
        public virtual string Code { get; set; }

        [Required]
        public virtual ClassType? Type { get; internal set; }

        [Required]
        [MaxLength(64)]
        public virtual string Location { get; set; } // is this just descriptive text?

        public virtual Course Course { get; set; }

        public virtual Guid CourseId { get; private set; }

        public virtual Organization School { get; set; }

        public virtual Guid SchoolId { get; private set; }

        public virtual AcademicSession AcademicSession { get; set; }

        public virtual Guid AcademicSessionId { get; private set; }

        public virtual ISet<Enrollment> Users { get; } = new HashSet<Enrollment>();

        public virtual ISet<ClassResource> Resources { get; } = new HashSet<ClassResource>();

        public virtual ISet<LineItem> LineItems { get; } = new HashSet<LineItem>();

        public virtual Status Status { get; set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual DateTimeOffset Modified { get; private set; }

        // TODO periods... grading periods?

        // TODO subjects, subject codes

        // TODO terms

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            switch (AcademicSession.Type)
            {
                case AcademicSessionType.Semester:
                case AcademicSessionType.Term:
                    // TODO validate
                    yield break;
            }
        }
    }
}