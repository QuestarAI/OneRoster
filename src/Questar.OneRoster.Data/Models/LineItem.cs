namespace Questar.OneRoster.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class LineItem : IBaseObject
    {
        public virtual Guid LineItemId { get; private set; }

        public virtual Class Class { get; private set; }

        public virtual Guid ClassId { get; private set; }

        public virtual Category Category { get; private set; }

        public virtual Guid CategoryId { get; private set; }

        public virtual ISet<Result> Results { get; } = new HashSet<Result>();

        public virtual Status Status { get; set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual DateTimeOffset Modified { get; private set; }
    }
}