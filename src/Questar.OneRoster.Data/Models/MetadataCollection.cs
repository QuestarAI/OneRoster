namespace Questar.OneRoster.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class MetadataCollection
    {
        public virtual Guid MetadataCollectionId { get; private set; }

        public virtual ISet<Metadata> Metadata { get; } = new HashSet<Metadata>();
    }
}