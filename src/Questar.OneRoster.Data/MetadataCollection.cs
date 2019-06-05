using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questar.OneRoster.Data
{
    public class MetadataCollection
    {
        internal MetadataCollection()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)] [MaxLength(10)] public virtual string Id { get; internal set; }

        public virtual ICollection<Metadata> Metadata { get; } = new HashSet<Metadata>();
    }
}