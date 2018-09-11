namespace Questar.OneRoster.Data.Models
{
    using System;

    public class Enrollment : IBaseObject
    {
        public virtual Guid EnrollmentId { get; private set; }

        public virtual DateTimeOffset? BeginDate { get; set; }

        public virtual DateTimeOffset? EndDate { get; set; }

        public virtual Status Status { get; set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual DateTimeOffset Modified { get; private set; }
    }
}