namespace Questar.OneRoster.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Class : IBaseObject
    {
        public Class(ClassType type) =>
            Type = type;

        private Class()
        {
        }

        [Required]
        public virtual ClassType? Type { get; private set; }

        [Required]
        [MaxLength(256)]
        public virtual string Title { get; set; }

        [MaxLength(32)]
        public virtual string Code { get; set; }

        [MaxLength(256)]
        public virtual string Location { get; set; }

        public virtual Course Course { get; set; }

        [Required]
        public virtual string CourseId { get; private set; }

        public virtual Org School { get; set; }

        [Required]
        public virtual string SchoolId { get; private set; }

        public virtual ICollection<ClassGrade> Grades { get; } = new HashSet<ClassGrade>();

        public virtual ICollection<ClassSubject> Subjects { get; } = new HashSet<ClassSubject>();

        public virtual ICollection<ClassPeriod> Periods { get; } = new HashSet<ClassPeriod>();

        public virtual ICollection<ClassAcademicSession> Terms { get; } = new HashSet<ClassAcademicSession>();

        public virtual ICollection<ClassResource> Resources { get; } = new HashSet<ClassResource>();

        public virtual ICollection<Enrollment> Enrollments { get; } = new HashSet<Enrollment>();

        public virtual ICollection<LineItem> LineItems { get; } = new HashSet<LineItem>();

        #region Base Object

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual string Id { get; private set; } = Guid.NewGuid().ToString().Substring(0, 10);

        public virtual MetadataCollection MetadataCollection { get; private set; } = new MetadataCollection();

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual Status Status { get; private set; }

        public virtual DateTime Modified { get; private set; }

        #endregion
    }
}