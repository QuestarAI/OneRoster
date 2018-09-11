namespace Questar.OneRoster.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class MetadataCollection
    {
        public virtual Guid MetadataCollectionId { get; private set; }

        public virtual ISet<Metadata> Metadata { get; } = new HashSet<Metadata>();
    }
}