namespace Questar.OneRoster.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AcademicSession : IBaseObject
    {
        public AcademicSession(AcademicSessionType type) =>
            Type = type;

        private AcademicSession()
        {
        }

        [Required]
        public AcademicSessionType Type { get; private set; }

        [Required]
        [MaxLength(256)]
        public virtual string Title { get; set; }

        [Required]
        public virtual DateTime? StartDate { get; set; }

        [Required]
        public virtual DateTime? EndDate { get; set; }

        public virtual AcademicSession Parent { get; set; }

        public virtual Guid? ParentId { get; private set; }

        public virtual ICollection<AcademicSession> Children { get; } = new HashSet<AcademicSession>();

        [Required]
        public virtual int? SchoolYear { get; set; }

        // term or semester only
        public virtual IReadOnlyCollection<ClassAcademicSession> Classes { get; } = new HashSet<ClassAcademicSession>();

        // grading period only
        public virtual IReadOnlyCollection<LineItem> LineItems { get; } = new HashSet<LineItem>();

        #region Base Object

        public virtual Guid Id { get; private set; }

        public virtual MetadataCollection MetadataCollection { get; private set; } = new MetadataCollection();

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual Status Status { get; private set; }

        public virtual DateTime Modified { get; private set; }

        #endregion
    }
}