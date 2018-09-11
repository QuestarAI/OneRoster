namespace Questar.OneRoster.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Metadata
    {
        public virtual MetadataCollection Collection { get; private set; }

        public virtual Guid CollectionId { get; private set; }

        [Required]
        [MaxLength(64)]
        public virtual string Key { get; set; }

        [MaxLength(256)]
        public virtual string Value { get; set; }
    }
}