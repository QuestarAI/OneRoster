namespace Questar.OneRoster.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AcademicSession : IBaseObject
    {
        public virtual Guid AcademicSessionId { get; private set; }

        [Required]
        [MaxLength(256)]
        public virtual string Title { get; set; }

        public virtual DateTimeOffset StartDate { get; set; }

        public virtual DateTimeOffset EndDate { get; set; }

        // TODO factory?
        [Required]
        public AcademicSessionType? Type { get; internal set; }

        public virtual AcademicSession Parent { get; set; }

        public virtual Guid? ParentId { get; private set; }

        public virtual ISet<AcademicSession> Children { get; } = new HashSet<AcademicSession>();

        // TODO string?
        // TODO research min/max value
        [Range(0, 9999)]
        public virtual int SchoolYear { get; set; }

        public virtual Status Status { get; set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual DateTimeOffset Modified { get; private set; }

        // TODO is this visible from this direction?
        // TODO terms and semesters only - AcademicSessionClassCollection?
        // public virtual ISet<Class> Classes { get; } = new HashSet<Class>();
    }
}