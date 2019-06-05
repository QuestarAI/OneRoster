using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questar.OneRoster.Data
{
    public class Course : IBaseObject
    {
        [Required] [MaxLength(256)] public virtual string Title { get; set; }

        [MaxLength(256)] public virtual string Code { get; set; }

        public virtual AcademicSession SchoolYear { get; set; }

        public virtual string SchoolYearId { get; internal set; }

        public virtual Org Org { get; set; }

        public virtual string OrgId { get; internal set; }

        public virtual ICollection<CourseGrade> Grades { get; } = new HashSet<CourseGrade>();

        public virtual ICollection<CourseSubject> Subjects { get; } = new HashSet<CourseSubject>();

        public virtual ICollection<CourseResource> Resources { get; } = new HashSet<CourseResource>();

        public virtual ICollection<Class> Classes { get; } = new HashSet<Class>();

        #region Base Object

        [DatabaseGenerated(DatabaseGeneratedOption.None)] [MaxLength(10)] public virtual string Id { get; internal set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual string MetadataCollectionId { get; internal set; }

        public virtual Status Status { get; internal set; }

        public virtual DateTime Modified { get; internal set; }

        #endregion
    }
}