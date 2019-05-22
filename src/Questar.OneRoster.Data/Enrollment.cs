namespace Questar.OneRoster.Data
{
    using System;

    public class Enrollment : IBaseObject
    {
        public Enrollment(Class @class) =>
            Class = @class;

        private Enrollment()
        {
        }

        public virtual DateTime? BeginDate { get; set; }

        public virtual DateTime? EndDate { get; set; }

        public virtual User User { get; private set; }

        public virtual Guid UserId { get; private set; }

        public virtual Class Class { get; private set; }

        public virtual Guid ClassId { get; private set; }

        // applicable only to teachers
        public virtual bool? Primary { get; set; }

        #region Base Object

        public virtual Guid Id { get; private set; }

        public virtual MetadataCollection MetadataCollection { get; private set; } = new MetadataCollection();

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual Status Status { get; private set; }

        public virtual DateTime Modified { get; private set; }

        #endregion
    }
}