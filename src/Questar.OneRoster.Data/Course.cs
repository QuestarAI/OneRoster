namespace Questar.OneRoster.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course : IBaseObject
    {
        [Required]
        [MaxLength(256)]
        public virtual string Title { get; set; }

        [MaxLength(256)]
        public virtual string Code { get; set; }

        public virtual AcademicSession SchoolYear { get; set; } // TODO one-time only?

        public virtual Guid SchoolYearId { get; private set; }

        public virtual Org Organization { get; set; } // TODO one-time only?

        public virtual Guid OrganizationId { get; private set; }

        public virtual ICollection<CourseGrade> Grades { get; } = new HashSet<CourseGrade>();

        public virtual ICollection<CourseSubject> Subjects { get; } = new HashSet<CourseSubject>();

        public virtual ICollection<CourseResource> Resources { get; } = new HashSet<CourseResource>();

        public virtual ICollection<Class> Classes { get; } = new HashSet<Class>();

        #region Base Object

        public virtual Guid Id { get; private set; }

        public virtual MetadataCollection MetadataCollection { get; private set; } = new MetadataCollection();

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual bool Active { get; private set; }

        public virtual DateTimeOffset Modified { get; private set; }

        #endregion
    }
}