using System.Collections.Generic;

namespace Questar.OneRoster.Data
{
    public class MetadataCollection
    {
        internal MetadataCollection()
        {
        }

        public virtual int Id { get; internal set; }

        public virtual ICollection<Metadata> Metadata { get; } = new HashSet<Metadata>();
    }
}