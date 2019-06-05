using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questar.OneRoster.Data
{
    public class AcademicSession : IBaseObject
    {
        internal AcademicSession()
        {
        }

        public AcademicSession(AcademicSessionType type)
        {
            Type = type;
        }

        [Required] public AcademicSessionType Type { get; internal set; }

        [Required] [MaxLength(256)] public virtual string Title { get; set; }

        [Required] public virtual DateTime? StartDate { get; set; }

        [Required] public virtual DateTime? EndDate { get; set; }

        public virtual AcademicSession Parent { get; set; }

        public virtual string ParentId { get; internal set; }

        public virtual ICollection<AcademicSession> Children { get; } = new HashSet<AcademicSession>();

        [Required] public virtual int? SchoolYear { get; set; }

        // term or semester only
        public virtual IReadOnlyCollection<ClassAcademicSession> Classes { get; } = new HashSet<ClassAcademicSession>();

        // school year only
        public virtual IReadOnlyCollection<Course> Courses { get; } = new HashSet<Course>();

        // grading period only
        public virtual IReadOnlyCollection<LineItem> LineItems { get; } = new HashSet<LineItem>();

        #region Base Object

        [DatabaseGenerated(DatabaseGeneratedOption.None)] [MaxLength(10)] public virtual string Id { get; internal set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual string MetadataCollectionId { get; internal set; }

        public virtual Status Status { get; internal set; }

        public virtual DateTime Modified { get; internal set; }

        #endregion
    }
}