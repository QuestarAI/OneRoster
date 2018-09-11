namespace Questar.OneRoster.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class Category : IBaseObject
    {
        public virtual Guid CategoryId { get; private set; }

        public virtual ISet<LineItem> LineItems { get; } = new HashSet<LineItem>();

        public virtual Status Status { get; set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual DateTimeOffset Modified { get; private set; }
    }
}