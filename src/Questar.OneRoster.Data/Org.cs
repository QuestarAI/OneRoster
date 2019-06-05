using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questar.OneRoster.Data
{
    public class Org : IBaseObject
    {
        public Org(OrgType type)
        {
            Type = type;
        }

        internal Org()
        {
        }

        [Required] [MaxLength(256)] public virtual string Name { get; set; }

        [Required] public virtual OrgType? Type { get; internal set; }

        [MaxLength(256)] public virtual string Identifier { get; set; }

        public virtual Org Parent { get; set; }

        public virtual string ParentId { get; internal set; }

        public virtual ICollection<Org> Children { get; } = new HashSet<Org>();

        // schools only
        public virtual ICollection<Class> Classes { get; } = new HashSet<Class>();

        public virtual ICollection<Course> Courses { get; } = new HashSet<Course>();

        #region Base Object

        [DatabaseGenerated(DatabaseGeneratedOption.None)] [MaxLength(10)] public virtual string Id { get; internal set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual string MetadataCollectionId { get; internal set; }

        public virtual Status Status { get; internal set; }

        public virtual DateTime Modified { get; internal set; }

        #endregion
    }
}