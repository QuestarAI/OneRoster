namespace Questar.OneRoster.Data.Entities
{
    using System;

    public class Demographics : IBaseObject
    {
        public virtual User User { get; private set; }

        public virtual Guid UserId { get; private set; }

        public virtual Status Status { get; set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual DateTimeOffset Modified { get; private set; }
    }
}