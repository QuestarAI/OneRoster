namespace Questar.OneRoster.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Resource : IBaseObject
    {
        [MaxLength(64)]
        public virtual string Title { get; set; }

        [Required]
        public virtual Importance? Importance { get; set; }

        [Required]
        [MaxLength(256)]
        public virtual string VendorResourceId { get; set; }

        [MaxLength(256)]
        public virtual string VendorId { get; set; }

        [MaxLength(256)]
        public virtual string ApplicationId { get; set; }

        public virtual ICollection<ResourceRole> Roles { get; } = new HashSet<ResourceRole>();

        public virtual IReadOnlyCollection<ClassResource> Classes { get; } = new HashSet<ClassResource>();

        public virtual IReadOnlyCollection<CourseResource> Courses { get; } = new HashSet<CourseResource>();

        #region Base Object

        public virtual Guid Id { get; private set; }

        public virtual MetadataCollection MetadataCollection { get; private set; } = new MetadataCollection();

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual Status Status { get; private set; }

        public virtual DateTime Modified { get; private set; }

        #endregion
    }
}