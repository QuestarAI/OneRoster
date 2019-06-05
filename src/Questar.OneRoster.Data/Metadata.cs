using System.ComponentModel.DataAnnotations;

namespace Questar.OneRoster.Data
{
    public class Metadata
    {
        public virtual MetadataCollection Collection { get; internal set; }

        public virtual string CollectionId { get; internal set; }

        [Required] [MaxLength(64)] public virtual string Key { get; set; }

        [MaxLength(256)] public virtual string Value { get; set; }
    }
}