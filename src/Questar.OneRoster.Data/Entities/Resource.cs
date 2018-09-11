namespace Questar.OneRoster.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Resource : IBaseObject
    {
        public Guid ResourceId { get; private set; }

        [Required]
        [MaxLength(64)]
        public virtual string Title { get; set; }

        public virtual ISet<ResourcePosition> Positions { get; } = new HashSet<ResourcePosition>();

        public Status Status { get; set; }

        public MetadataCollection MetadataCollection { get; set; }

        public Guid? MetadataCollectionId { get; private set; }

        public DateTimeOffset Modified { get; private set; }
    }
}