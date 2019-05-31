namespace Questar.OneRoster.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course : IBaseObject
    {
        [Required]
        [MaxLength(256)]
        public virtual string Title { get; set; }

        [MaxLength(256)]
        public virtual string Code { get; set; }

        public virtual AcademicSession SchoolYear { get; set; }

        [Required]
        public virtual string SchoolYearId { get; private set; }

        public virtual Org Org { get; set; }

        [Required]
        public virtual string OrgId { get; private set; }

        public virtual ICollection<CourseGrade> Grades { get; } = new HashSet<CourseGrade>();

        public virtual ICollection<CourseSubject> Subjects { get; } = new HashSet<CourseSubject>();

        public virtual ICollection<CourseResource> Resources { get; } = new HashSet<CourseResource>();

        public virtual ICollection<Class> Classes { get; } = new HashSet<Class>();

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