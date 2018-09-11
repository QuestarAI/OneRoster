namespace Questar.OneRoster.Data.Entities
{
    using System;

    public class Result : IBaseObject
    {
        public Guid ResultId { get; private set; }

        public LineItem LineItem { get; private set; }

        public Guid LineItemId { get; private set; }

        public User User { get; private set; }

        public Guid UserId { get; private set; }

        public Status Status { get; set; }

        public MetadataCollection MetadataCollection { get; set; }

        public Guid? MetadataCollectionId { get; private set; }

        public DateTimeOffset Modified { get; private set; }
    }
}