using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questar.OneRoster.Data
{
    public class Class : IBaseObject
    {
        internal Class()
        {
        }

        public Class(ClassType type)
        {
            Type = type;
        }

        [Required] public virtual ClassType? Type { get; internal set; }

        [Required] [MaxLength(256)] public virtual string Title { get; set; }

        [MaxLength(32)] public virtual string Code { get; set; }

        [MaxLength(256)] public virtual string Location { get; set; }

        public virtual Course Course { get; set; }

        public virtual string CourseId { get; internal set; }

        public virtual Org School { get; set; }

        public virtual string SchoolId { get; internal set; }

        public virtual ICollection<ClassGrade> Grades { get; } = new HashSet<ClassGrade>();

        public virtual ICollection<ClassSubject> Subjects { get; } = new HashSet<ClassSubject>();

        public virtual ICollection<ClassPeriod> Periods { get; } = new HashSet<ClassPeriod>();

        public virtual ICollection<ClassAcademicSession> Terms { get; } = new HashSet<ClassAcademicSession>();

        public virtual ICollection<ClassResource> Resources { get; } = new HashSet<ClassResource>();

        public virtual ICollection<Enrollment> Enrollments { get; } = new HashSet<Enrollment>();

        public virtual ICollection<LineItem> LineItems { get; } = new HashSet<LineItem>();

        #region Base Object

        [DatabaseGenerated(DatabaseGeneratedOption.None)] [MaxLength(10)] public virtual string Id { get; internal set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual string MetadataCollectionId { get; internal set; }

        public virtual Status Status { get; internal set; }

        public virtual DateTime Modified { get; internal set; }

        #endregion
    }
}