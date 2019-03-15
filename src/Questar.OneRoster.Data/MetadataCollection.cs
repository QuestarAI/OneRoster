namespace Questar.OneRoster.Data
{
    using System;
    using System.Collections.Generic;

    public class MetadataCollection
    {
        internal MetadataCollection()
        {
        }

        public virtual Guid MetadataCollectionId { get; private set; }

        public virtual ICollection<Metadata> Metadata { get; } = new HashSet<Metadata>();
    }
}