namespace Questar.OneRoster.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Org : IBaseObject
    {
        public Org(OrgType type) =>
            Type = type;

        private Org()
        {
        }

        [Required]
        [MaxLength(256)]
        public virtual string Name { get; set; }

        [Required]
        public virtual OrgType? Type { get; private set; }

        [MaxLength(256)]
        public virtual string Identifier { get; set; }

        public virtual Org Parent { get; set; } // TODO one-time only? no...

        public virtual Guid? ParentId { get; private set; }

        public virtual ICollection<Org> Children { get; } = new HashSet<Org>();

        // schools only
        public virtual IReadOnlyCollection<Class> Classes { get; } = new HashSet<Class>();

        public virtual ICollection<Course> Courses { get; } = new HashSet<Course>();

        #region Base Object

        public virtual Guid Id { get; private set; }

        public virtual MetadataCollection MetadataCollection { get; private set; } = new MetadataCollection();

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual Status Status { get; private set; }

        public virtual DateTime Modified { get; private set; }

        #endregion
    }
}