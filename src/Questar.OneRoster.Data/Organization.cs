namespace Questar.OneRoster.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Organization : IBaseObject
    {
        public Organization(OrganizationType type) => Type = type;

        private Organization()
        {
        }

        [Required]
        [MaxLength(256)]
        public virtual string Name { get; set; }

        [Required]
        public virtual OrganizationType? Type { get; private set; }

        [MaxLength(256)]
        public virtual string Identifier { get; set; }

        public virtual Organization Parent { get; set; } // TODO one-time only? no...

        public virtual Guid? ParentId { get; private set; }

        public virtual ICollection<Organization> Children { get; } = new HashSet<Organization>();

        // schools only
        public virtual IReadOnlyCollection<Class> Classes { get; } = new HashSet<Class>();

        public virtual ICollection<Course> Courses { get; } = new HashSet<Course>();

        #region Base Object

        public virtual Guid Id { get; private set; }

        public virtual MetadataCollection MetadataCollection { get; private set; } = new MetadataCollection();

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual bool Active { get; private set; }

        public virtual DateTimeOffset Modified { get; private set; }

        #endregion
    }
}