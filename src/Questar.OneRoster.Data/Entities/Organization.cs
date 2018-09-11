namespace Questar.OneRoster.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Organization : IBaseObject
    {
        public virtual Guid OrganizationId { get; private set; }

        [Required]
        public virtual OrganizationType? Type { get; internal set; }

        [Required]
        [MaxLength(256)]
        public virtual string Title { get; set; }

        public virtual Organization Parent { get; set; }

        public virtual Guid ParentId { get; private set; }

        public virtual ISet<Organization> Children { get; } = new HashSet<Organization>();

        public virtual Status Status { get; set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual DateTimeOffset Modified { get; private set; }

        //public virtual ISet<AcademicSession> AcademicSessions { get; } = new HashSet<AcademicSession>();

        // TODO schools only?
        //public virtual ISet<Course> Courses { get; } = new HashSet<Course>();

        // TODO schools only?
        //public virtual ISet<Enrollment> Teachers { get; } = new HashSet<Enrollment>();

        // TODO schools only?
        //public virtual ISet<Enrollment> Users { get; } = new HashSet<Enrollment>();
    }
}